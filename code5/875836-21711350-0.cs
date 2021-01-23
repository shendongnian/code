        static void Main(string[] args)
        {
            Dictionary<string, string> ordering = new Dictionary<string, string>()
                {
                   { "g", "d" }, { "s", "e" }, { "e", "g" }
                };
            List<string> source = new List<string>() { "e", "s", "g" };
            List<string> result = source.OrderBy(key => ordering[key]).ToList();
            foreach (string s in result) { Console.Write(s + " "); }
            Console.WriteLine();
        }
