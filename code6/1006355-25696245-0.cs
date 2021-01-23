        static void Main(string[] args)
        {
            List<string> keys = new List<string>();
            keys.Add("TYPE");
            keys.Add("SIGNATURE");
            keys.Add("CLIENT NAME");
            string multilineString =
                @"TYPE Email Forwarding
                SIGNATURE mysig.html
                COMPANY Smith Incorp
                CLIENT NAME James Henries";
            var lines = multilineString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var key in keys)
            {
                var filteredLines = lines.Where(l => l.Trim().StartsWith(key)).ToList();
                foreach (var line in filteredLines)
                {
                    Console.WriteLine(line.Trim().Remove(0, key.Length + 1));
                }
            }
            Console.ReadLine();
        }
