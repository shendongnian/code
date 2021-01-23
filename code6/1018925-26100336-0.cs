    var c = MyCache.Get[key]();
    if (c == null)
    {
        c = methodToCallWithParameter(key);
        MyCache.Add(key, c);
    }
    return c;
