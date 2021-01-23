    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                BeginTesting();
                Console.ReadLine();
            }
    
            private static void BeginTesting()
            {
                //Step 1 : Print number 1 to 100
                for (int i = 1; i <= 100; i++)
                {
    
                    // Step 2 :- Divisable by 9 print Fizz
                    if (isDivisibleBy(i, 9))
                    {
                        Console.WriteLine("Fizz");
                    }
    
                    // Step 3 :- Divisable by 13 print Buzz
                    else if (isDivisibleBy(i, 13))
                    {
                        Console.WriteLine("Buzz");
                    }
    
                    // Step 4 :- Divisable by 9 and 13 print FizzBuzz
                    else if (isDivisibleBy(i, 9) && isDivisibleBy(i, 13))
                    {
                        Console.WriteLine("FizzBuzz");
                    }
    
                    // Step 5 :- Print the number as it is if not divisable by 9 or 13
                    else
                    {
                        Console.WriteLine(i);
                    }
    
                }
            }
    
    
    
            //Create a method to test whether it’s divisible
            private static bool isDivisibleBy(int theNumber, int theDivisor)
            {
                bool isDivisible = false;
    
                if ((theNumber % theDivisor) == 0)
                {
                    isDivisible = true;
                }
    
                return isDivisible;
            }
    
    
        }
    }
