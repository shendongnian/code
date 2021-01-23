    var groups = items.GroupBy(p => p.Property);
    foreach (var group in groups)
    {
        Console.WriteLine(group.Key);
        foreach (var item in group)
        {
            Console.WriteLine("\t{0}", item.AnotherProperty); 
        }
    }
