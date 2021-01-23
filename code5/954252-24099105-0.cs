    foreach (var item in lookupTable)
    {
        Console.WriteLine(item.Key);
        foreach (var obj in item)
        {
            Console.WriteLine(obj);
        }
    }
