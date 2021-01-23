        static void Main(string[] args)
        {
            //Assuming that you know all of the keys before hand
            List<string> keys = new List<string>() { "TYPE", "SIGNATURE", "COMPANY", "CLIENT NAME" };
            //Not sure of the origin of your string to parse.  You would have to change
            //this to read a file or query the DB or whatever
            string multilineString =
                @"TYPE Email Forwarding
                SIGNATURE mysig.html
                COMPANY Smith Incorp
                CLIENT NAME James Henries";
            //Split the string by newlines.
            var lines = multilineString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            //Iterate over keys because you probably have less keys than data in the event of duplicates
            foreach (var key in keys)
            {
                //Reduce list of lines to check based on ones that start with a given key
                var filteredLines = lines.Where(l => l.Trim().StartsWith(key)).ToList();
                foreach (var line in filteredLines)
                {
                    Console.WriteLine(line.Trim().Remove(0, key.Length + 1));
                }
            }
            Console.ReadLine();
        }
