    Dictionary<int,item> l2dic = List2.ToDictionary(x => x.identifier);
    item itm;
    List1.ForEach(x => {
        if(l2dic.TryGetValue(x.identifier,out itm)) {
            x.name = itm.name;
        }
    });
