    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Calculator
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Calculator V1.00");
                Console.WriteLine("----------------");
                Console.WriteLine("");
                Console.WriteLine("Enter a number:");
                double value = GetValue();
                bool bool2 = false;
                Console.WriteLine("----------------");
                Console.WriteLine("----------------");
                Console.WriteLine("Now enter an operator such as '+' or '*' ");
    
                while (bool2 == false)
                {
                    try
                    {
                        char op = Convert.ToChar(Console.ReadLine());
                        bool2 = true;
                        Console.WriteLine("");
                        Console.WriteLine("Now input your second number");
                        Console.WriteLine("----------------------------");
                        double value2 = GetValue();
                        if (op == Convert.ToChar("+"))
                        {
                            double result =  value + value2;
                                Console.WriteLine(result);
                        }
                    
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Now enter an operator such as '+' or '*' ");
                        bool2 = false;
                    }
                }
            }
            private static double GetValue()
            {
                bool bool1 = false;
                while (bool1 == false)
                {
                    try
                    {
                            return Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter a number");
                        bool1 = false;
                    }
                }
                throw new InvalidOperationException();
            }
        }
    }
