        using System.Text.RegularExpressions;
        static void Main(string[] args)
        {
            string str = "mynewtime10:20:13.458atcertainplace";
            string patt = @"([0-9:.]+)";
            Regex rgx = new Regex(patt, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(str);
            if (matches.Count > 0)
            {
                Console.WriteLine("{0} ({1} matches):", str, matches.Count);
                foreach (Match match in matches)
                    Console.WriteLine("   " + match.Value);
            }
                Console.ReadLine();
        }
