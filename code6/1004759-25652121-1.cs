    var dict = new ConcurrentDictionary<Tuple<int, object, string>, Beneficiary>();
    Parallel.ForEach(cx, _options, line =>
    {
        string fullname = string.Join("|", line.FirstName, line.LastName, line.MiddleName);
    
        Tuple<int, object, string> key = new Tuple<int,object,string>(line.WinID, line.ProductType, fullname);
        if (!dict.ContainsKey(key))
        {
            dict.TryAdd(key, line);}
        }
    });
