    var dicCommon = new Dictionary<int, int>();
    dicCommon.Add(6, 4);
    dicCommon.Add(3, 4);
    dicCommon.Add(2, 2);
    dicCommon.Add(1, 1);
    var maxGroup = dicCommon.GroupBy(x => x.Value).OrderByDescending(x => x.Key).FirstOrDefault();
    foreach (var keyValuePair in maxGroup)
    {
        Console.WriteLine("Key: {0}, Value {1}", keyValuePair.Key, keyValuePair.Value);
    }
