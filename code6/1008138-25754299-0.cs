    var list = new List<string>();
    foreach(var item in dictionary)
    {
        list.Add(item.Value);
    }
    var newDict = new Dictionary<int, string>();
    for(int i = 1; i < list.Count + 1; i++)
    {
        newDict.Add(i,list[i]);
    }
