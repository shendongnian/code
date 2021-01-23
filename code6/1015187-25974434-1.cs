    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                string original = "hello";
                var encoded = ToDecimalAscii(original);
                Console.WriteLine("Encoded:");
                Console.WriteLine(string.Join("\n", encoded));
                Console.WriteLine("\nDecoded: " + FromDecimalAscii(encoded));
            }
            public static List<string> ToDecimalAscii(string input)
            {
                var result = new List<string>();
            
                foreach (char c in input)
                    result.Add(((int)c).ToString());
                return result;
            }
            public static string FromDecimalAscii(IEnumerable<string> input)
            {
                return new string(input.Select(s => (char)int.Parse(s)).ToArray());
            }
        }
    }
