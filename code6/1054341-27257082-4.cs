    var list1 = dic.Where(x => x.Value == Where.First).ToList();
    var list2 = dic.Where(x => x.Value == Where.Second).ToList();
    
    foreach (var kv in list1)
    {
        Console.WriteLine("{0}: {1}", kv.Key, kv.Value);
    }
    
    foreach (var kv in list2)
    {
        Console.WriteLine("{0}: {1}", kv.Key, kv.Value);
    }
