        using System;
    
    namespace Student_Challenge_Lab_2
    {
        internal class Program
        {
            // main method begins the execution of C# program
            private static void Main(string[] args)
            {
                // following code prompts user to input the two sets of integers
                Console.Write("Please enter your integer: ");
                var number1 = Convert.ToInt32(Console.ReadLine());
                // the program now tests to see if the integer is even or odd. If the remainder is        0 it is an even integer
                Console.Write(number1 % 2 == 0 ? "Your integer ({0}) is even." : "Your integer ({0}) is odd.", number1);
                Console.ReadKey();
            }
        }
        // end main
    }
    // end Student challenge lab 2
