    using System;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Int32 a = 3;
                Int32 b = 5;
                a = Console.Read();
                try
                {
                    b = Convert.ToInt32(Console.ReadLine());
                    Int32 a_plus_b = a + b;
                    Console.WriteLine("a + b =" + a_plus_b.ToString());
                }
                catch (FormatException e)
                {
                    // Error handling, becuase the input couldn't be parsed to a integer.
                }
            }
        }
    }
