     using System;
     class SumDoubles
     {
        static void Main()
        {   
            //Declare variables
            double DblSumTotal = 0;
            double LIMIT = 0;
    
    
            //Ask user to input 5 numbers to be added
            Console.Clear();
            Console.WriteLine("Enter 5 numbers to be added together.");
            do 
            {
                double d;
                if (!double.TryParse(Console.ReadLine(), out d)) {
                    Console.WriteLine("Format error!!!");
                } else {
                    DblSumTotal = DblSumTotal + d;
                    LIMIT = LIMIT + 1;
                }
               
            } while (LIMIT < 5);
    
            //Output total
            Console.WriteLine("The total sum of the 5 numbers is " + DblSumTotal);
            Console.ReadLine();
        }   
    }
