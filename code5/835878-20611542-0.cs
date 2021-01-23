    List<int> list;
    if(!myDict.TryGetValue(newKey, out list))
    {
        list = new List<int>();
        myDict.Add(newKey, list);
    }
    list.Add(myNumber);
