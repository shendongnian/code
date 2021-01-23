    // read lines somehow
    // ...
    // create a list
    var list = new List<Tuple<string, string, string>>();
    foreach(string line in lines)
    {
        var split = line.Split('\x9');
        list.Add(new Tuple(split[0], split[1], split[2]));
    }
    // sort
    list = list.OrderBy(x => x.Item3);
    // remove duplicates
    for(int i = 1; i < list.Count; i++)
        if(list[i].Item3 == list[i-1].Item3)
            list.RemoveAt(i);
