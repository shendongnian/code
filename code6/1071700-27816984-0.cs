    var groups = List.GroupBy(obj => obj.PropA);
    foreach (var group in groups)
    {
        foreach (var item in group.Skip(1))
        {
            item.PropA = "";
            item.PropB = "";
        }
    }
