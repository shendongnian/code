    var dict = new Dictionary<int, int>();
    dict.Add(1,1);
    var q = dict.AsQueryable();
    Type tInfo = q.GetType();
    PropertyInfo pInfo = tInfo.GetProperties(BindingFlags.NonPublic | 
                                             BindingFlags.Instance)
                              .FirstOrDefault(p => p.Name == "Enumerable");
    if (pInfo != null)
    {
        var originalDictionary = pInfo.GetValue(q, null);
        Console.WriteLine(dict == originalDictionary);  // true
    }
