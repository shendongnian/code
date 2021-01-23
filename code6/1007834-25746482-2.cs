    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static string StripZ(string s)
            {
                if (s.Contains("."))
                {
                    Regex regex = new Regex("\\.?0*$");
                    s = regex.Replace(s, "");
                }
                return s;
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine(StripZ("123.400"));
                Console.WriteLine(StripZ("3.0"));
                Console.WriteLine(StripZ("7."));
                Console.WriteLine(StripZ("1000"));
                Console.ReadLine();
            }
        }
    }
