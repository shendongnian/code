    using System;
    
    namespace DelegateSample
    {
        public class Program
        {
            // delegate to handle tryparse
            public delegate bool TryParse<T>(string txt, out T desiredNumber);
    
            // generic function that will get a number from a user and utilize the existing TryParse for the specified type
            public static T GetNumberFromUser<T>(string info, TryParse<T> tryParseFunction)
            {
                T TheDesiredNumber;
    
                while (true)
                {
                    Console.Write("Please type " + info + " : ");
    
                    string input = Console.ReadLine();
    
                    // use the delegate here to run the TryParse, which is passed in
                    if (tryParseFunction(input, out TheDesiredNumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" - " + info + " is set to " + TheDesiredNumber.ToString() + "!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return TheDesiredNumber;
                    }
    
                    // WrongInput isn't defined, this should suffice for the sample
                    Console.WriteLine(input + " - Invalid input!");
                }
            }
    
            public static void Main(string[] args)
            {
                // this can be used for any function which implements the TryParse function which matches the delegate
                // it is a simple function call.  Specify the type between the brackets, and then pass the function in that
                // does the TryParse.  You could even write your own TryParse for your own classes, if needed.
                int iVal = GetNumberFromUser<int>("integer", int.TryParse);
                double dVal = GetNumberFromUser<double>("double", double.TryParse);
                float fVal = GetNumberFromUser<float>("float", float.TryParse);
            }
        }
    }
