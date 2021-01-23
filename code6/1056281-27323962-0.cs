    class Program
    {
        static void Main(string[] args)
        {
            DateTime? storeDate = null;
            using (var reader = new StreamReader(@"c:\example.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var m = Regex.Match(line, @"Damian:\s*(?<storedate>[0-9]{4}/[0-9]{2}/[0-9]{2})");
                    if (m.Success)
                    {
                        storeDate = DateTime.Parse(m.Groups["storedate"].Value);
                        // break;
                    }
                }
            }
            if (storeDate.HasValue)
                Console.WriteLine("StoreDate = " + storeDate.Value);
            Console.ReadKey();
        }
    }
