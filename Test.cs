using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please give unit price for A");
            if (int.TryParse(Console.ReadLine(), out int priceForA))
            {
                Console.WriteLine("Unit Price for A is : " + priceForA);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Please give unit price for B");
            if (int.TryParse(Console.ReadLine(), out int priceForB))
            {
                Console.WriteLine("Unit Price for B is : " + priceForB);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Please give unit price for C");
            if (int.TryParse(Console.ReadLine(), out int priceForC))
            {
                Console.WriteLine("Unit Price for C is : " + priceForC);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Please give unit price for D");
            if (int.TryParse(Console.ReadLine(), out int priceForD))
            {
                Console.WriteLine("Unit Price for D is : " + priceForD);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            Console.WriteLine("Set Active Promotions");
            Console.WriteLine("For how many units of A you want to set promotion?");
            if (int.TryParse(Console.ReadLine(), out int unitsForA))
            {
                Console.WriteLine("Set promotional price for item A");
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            if (int.TryParse(Console.ReadLine(), out int promotionalPriceForA))
            {
                Console.WriteLine("Promotional price for {0} units of A is {1}", unitsForA, promotionalPriceForA);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            int totalPriceForA = 0;
            if (unitsForA > 0 && priceForA >=0 && promotionalPriceForA >=0)
            {
                totalPriceForA = CalculateTotalPriceForNUnits(unitsForA, priceForA, promotionalPriceForA, 'A');
            }

            Console.WriteLine("For how many units of B you want to set promotion?");
            if (int.TryParse(Console.ReadLine(), out int unitsForB))
            {
                Console.WriteLine("Set promotional price for item B");
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            if (int.TryParse(Console.ReadLine(), out int promotionalPriceForB))
            {
                Console.WriteLine("Promotional price for {0} units of B is {1}", unitsForB, promotionalPriceForB);
            }
            else
            {
                Console.WriteLine("Given value is not a number");
                KeyToExit();
            }
            int totalPriceForB = 0;
            if (unitsForB > 0 && priceForB >= 0 && promotionalPriceForB >= 0)
            {
                totalPriceForB = CalculateTotalPriceForNUnits(unitsForB, priceForB, promotionalPriceForB, 'B');
            }
            
            Console.WriteLine("Set promotional price for item C and D");
            int totalPriceForCAndD = 0;
            if (int.TryParse(Console.ReadLine(), out int promotionalPriceForCAndD))
            {
                if(priceForC + priceForD > promotionalPriceForCAndD)
                {
                    totalPriceForCAndD = CalculateTotalPriceForCAndDUnits(priceForC, priceForD, promotionalPriceForCAndD);
                }
                else
                {
                    Console.WriteLine("given wrong input");
                }
            }
            int totalprice = totalPriceForA + totalPriceForB + totalPriceForCAndD;
            Console.WriteLine("total amount " + totalprice);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
        private static int CalculateTotalPriceForNUnits(int unitsForSKU, int priceForSKU, int promotionalPriceForSKU, char SKU)
        {
            int promotionalNUnits = 0;
            Console.WriteLine("Please give total no of units for {0}", SKU);
            if (int.TryParse(Console.ReadLine(), out int totalUnitsForSKU))
            {
                promotionalNUnits = totalUnitsForSKU / unitsForSKU;
            }
            int normalUnits = totalUnitsForSKU % unitsForSKU;
            int totalPrice = (promotionalNUnits * promotionalPriceForSKU) + (normalUnits * priceForSKU);
            return totalPrice;
        }

        private static int CalculateTotalPriceForCAndDUnits(int priceForC, int priceForD, int promotionalPriceForSKU)
        {
            int totalUnitsForC = 0;
            int totalUnitsForD = 0;
            int totalPriceforCAndD = 0;
            int normalUnit = 0;
            Console.WriteLine("Please give total no of units for C");
            int.TryParse(Console.ReadLine(), out totalUnitsForC);
            Console.WriteLine("Please give total no of units for D");
            int.TryParse(Console.ReadLine(), out totalUnitsForD);
            if(totalUnitsForC == totalUnitsForD)
            {
                totalPriceforCAndD = totalUnitsForC * promotionalPriceForSKU;
            }
            else if(totalUnitsForC < totalUnitsForD)
            {
                if(totalUnitsForC == 1)
                {
                    totalPriceforCAndD = priceForD * (totalUnitsForD - 1) + promotionalPriceForSKU;
                }
                else if(totalUnitsForC == 0)
                {
                    totalPriceforCAndD = totalUnitsForD * priceForD;
                }
                else
                {
                    normalUnit = totalUnitsForD % totalUnitsForC;
                    totalPriceforCAndD = normalUnit * priceForD + totalUnitsForC * promotionalPriceForSKU;
                }                
            }
            else
            {
                if (totalUnitsForD == 1)
                {
                    totalPriceforCAndD = priceForC * (totalUnitsForC - 1) + promotionalPriceForSKU;
                }
                else if (totalUnitsForD == 0)
                {
                    totalPriceforCAndD = totalUnitsForC * priceForC;
                }
                else
                {
                    normalUnit = totalUnitsForC % totalUnitsForD;
                    totalPriceforCAndD = normalUnit * priceForC + totalUnitsForD * promotionalPriceForSKU;
                }
            }
            return totalPriceforCAndD;
        }
        private static void KeyToExit()
        {
            throw new ArgumentException("Given value is not integer");
        }
    }
}
