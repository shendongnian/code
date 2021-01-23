    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Exercise8
    {
        class Program
        {
            static void Main(string[] args)
            {    
                //declare variables    
                int casesSold;
                int costPerCase = 5; //Each case costs the Computer Club $5
                int numBars = 12; //There are 12 candy bars in each case
    
                double salePrice;
                double forSGA = .9; //The Student Government Association (SGA) will collect 10% of the earnings that the Computer Club makes
    
                string aCasesSold;
                string aSalePrice;
    
                //ask user for information
    
                Console.WriteLine("Please enter how many cases were sold:  ");
                aCasesSold = Console.ReadLine();
    
                Console.WriteLine("Please enter the sale price per candy bar: ");
                aSalePrice = Console.ReadLine();
    
                //Convert ints to strings so that they can be a part of the calculations
    
                casesSold = int.Parse(aCasesSold);
                salePrice = double.Parse(aSalePrice);
                
            } // you were missing this bracket.
    
            //calculate total cost for the Computer Club
                
            public static double CalculateTotalCost(double totalCost, int costPerCase, int casesSold)    
            {
               totalCost = costPerCase * casesSold;
               return totalCost;     
            }
    
            //calculate earnings for the Computer Club    
            public static double CalculateEarnings(int numBars, int casesSold, double earnings, double salePrice)    
            {
    
                earnings = numBars * salePrice * casesSold;
                return earnings;
    
            }
    
            //calculate proceeds    
            public static double CalculateProceeds(double proceeds, double forSGA, double earnings, double totalCost)    
            {
    
                proceeds = (forSGA * earnings) - totalCost;
                return proceeds;    
            }
    
            //output proceeds to user    
            public static void Output()    
            {    
                Console.WriteLine("The proceeds for the Computer Club are: {0;C}", CalculateProceeds(0.0, 0.0, 0.0, 0.0));
    
            }
        }
    }
