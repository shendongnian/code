    var set = new HashSet<string>();
    foreach(var outerItem in myDict)
    {
        set.Add(outerItem.Key);
        foreach(var innerKey in item.Value.Keys)
        {
            set.Add(innerKey);
        }
    }
