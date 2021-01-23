    static void Main(string[] args)
    {
        //TODO: Run your method to build entries.
        var entries = TestFill(); 
        var tree = entries.GroupBy(
            pair => pair.Key.ResourceId, 
            pair => new {EditionId = pair.Key.EditionId, LocationId = pair.Key.LocationId, ClickCount = pair.Value.ClickCount, ViewCount = pair.Value.ViewCount},
            (key, data) => new {ResourceId = key, Statistics = data.ToList()});
        var count = 0;
        foreach (var node in tree)
        {
            Console.Write("[" + (count++) + "]\t" + node.ResourceId);
            foreach (var item in node.Statistics)
            {
                Console.Write(String.Format(",{0},{1},{2},{3}", item.LocationId, item.EditionId, item.ClickCount, item.ViewCount));
            }
            Console.WriteLine();
        }
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }
  
