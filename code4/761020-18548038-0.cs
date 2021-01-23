    foreach(var group in duplicates)
    {
        Console.WriteLine("Duplicates of {0}:", group.Key)
        foreach(var x in group)
        {
            Console.WriteLine("- Index {0}:", x.Index)
        }
    }
