    [^RM]*RM[^RMT]+T[^RMT]*
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                String rg = "[^RM]*RM[^RMT]+T[^RMT]*";
                string input = "111RM----T222";
                // Here we call Regex.Match.
                Match match = Regex.Match(input, rg, RegexOptions.IgnoreCase);
                Console.WriteLine(match.Success);
            }
        }
    }
