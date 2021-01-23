    var strings = Enumerable.Range(0, 100).Select(i => i.ToString());
    int outValue = 0;
    var someEnumerable = strings.Where(s => int.TryParse(s, out outValue))
                                        .Select(s => outValue).ToArray();
    //outValue = 3;
    foreach (var i in someEnumerable)
    {
        Console.WriteLine(outValue);
    }
