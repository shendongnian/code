    if (NestedDictionary.ContainsKey(key1))
    {
        if (NestedDictionary[key1].ContainsKey(key2))
        {
           NestedDictionary[key1][key2][key3]=1;
        }
        else
        {
            NestedDictionary[key1].Add(key2, new Dictionary<int,int>() { { key3, 1 } });
        }
    }
    else
    {
        NestedDictionary.Add(key1, new Dictionary<int, Dictionary<int,int>>() { { key2, new Dictionary<int,int>() { { key3, 1} } } });
    }
