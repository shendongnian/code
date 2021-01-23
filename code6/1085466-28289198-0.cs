        static void Main()
        {
            var mapping = new[]
            {
                "BBZ",
                "B",
                "ABBA",
                "BZBZ",
                "BZAB",
                "BBZ",
                "ZBBAZ"
            };
            // the code
            var query = from c in mapping
                        where Regex.Match(c, ".*(B.*BZ)|(BZ.*B).*").Success
                        select c;
            Console.WriteLine("Matched:");
            foreach (string s in query)
            {
                Console.WriteLine(s);
            }
        }
