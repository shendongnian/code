    foreach (var group in groupByQuery)
    {
        Console.WriteLine(group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("    {0}", item);
        }
    }
