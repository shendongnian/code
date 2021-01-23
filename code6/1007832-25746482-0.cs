    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string s = "123.400";
                if (s.Contains("."))
                {
                    Regex regex = new Regex("0*$");
                    s = regex.Replace(s, "");
                }
                Console.WriteLine(s);
                Console.ReadLine();
            }
        }
    }
