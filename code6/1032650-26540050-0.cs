    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string exit = "";
                while(exit.ToLower != "no") 
                {
                    Console.WriteLine("What is the Temperature in Fahrenheit?");
                    string input = Console.ReadLine();
                    double tt = double.Parse (input);
                    double cc = (tt-32)*5/9;
                    Console.WriteLine(cc + " is the temperature in Celsius");
                    Console.WriteLine("if you want to do another conversion, enter \"yes\" otherwise, enter \"no\"");
                    exit = Console.ReadLine();
                }
            }
        }
    }
