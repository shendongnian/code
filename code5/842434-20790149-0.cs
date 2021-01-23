    List<TValue> list;
    if(!dictionary.TryGetValue(key, out list))
    {
      list = new List<TValue>();
      dictionary[key] = list;
    }
    
    list.Add("whatever...");
