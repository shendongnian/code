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
            public static IEnumerable<string> ToDecimalAscii(string input)
            {
                return input.Select(c => ((int)c).ToString());
            }
            public static string FromDecimalAscii(IEnumerable<string> input)
            {
                return new string(input.Select(s => (char)int.Parse(s)).ToArray());
            }
        }
    }
