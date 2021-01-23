    // sample IDictionary with an old Hashtable
    System.Collections.IDictionary sourceAttrs = new System.Collections.Hashtable
    { 
        {"athumB", "foo1"},
        {"other", "foo2"}
    };
    Dictionary<string, object> newGenericDict = sourceAttrs.Keys.Cast<string>()
        .Where(key => !key.Contains("thumb"))
        .ToDictionary(key => key, key => sourceAttrs[key]);
