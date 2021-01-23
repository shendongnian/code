    var result = DictA.ToDictionary(a => a.Key, a => DictB.ContainsKey(a.Value) ? DictB[a.Value] : a.Value);
    foreach (var item in result)
    {
        Console.WriteLine(item.Key + ", " + item.Value);
    }
