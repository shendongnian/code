    Dictionary<int,item> l2dic = List2.ToDictionary(x => x.identifier);
    item itm;
    foreach(item x in List1) {
        if(l2dic.TryGetValue(x.identifier,out itm)) {
            x.name = itm.name;
        }
    }
