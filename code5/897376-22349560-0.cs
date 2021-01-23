    List<int> list = null;
    if (dictionary.ContainsKey(key))
    {
        list = dictionary[key];
    }
    else
    {
        list = new List<int>();
        dictionary.Add(key, list);
    }
    list.Add(newValue);
