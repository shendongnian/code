    using System;
    
    namespace Student_Challenge_Lab_2
    {
        internal class Program
        {
            // main method begins the execution of C# program
            private static void Main(string[] args)
            {
                // following code prompts user to input the two sets of intergers
                Console.Write("Please enter your interger: ");
                var number1 = Convert.ToInt32(Console.ReadLine());
                // the program now tests to see if the interger is even or odd. If the remaider is        0 it is an even interger
                Console.Write(number1%2 == 0 ? "Your interger is even." : "Your interger is odd.", number1);
            }
        }
        // end main
    }
    // end Student challenge lab 2
