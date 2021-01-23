    using System;
    using MyExtensions;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string str1 = "tesx";
                var x = str1.RemoveByChar('x');
                Console.WriteLine(x);
                Console.ReadKey();
            }
        }
    }
    
    namespace MyExtensions
    {
        public static class StringExtensions
        {
            public static string RemoveByChar(this String str, char c)
            {
                return str.Remove(str.IndexOf(c), 1);
            }
        }
    }
