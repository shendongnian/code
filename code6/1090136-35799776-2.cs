        ILookup<string, string> lookup = // Convert to lookup
        foreach (IGrouping<string, string> grouping in lookup)
        {
            Console.WriteLine(grouping.Key + ":");
            foreach (string item in grouping)
            {
                Console.WriteLine("    item: " + item);
            }
        }
