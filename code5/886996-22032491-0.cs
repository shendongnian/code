    var actions = new List<Action<Item, Item>>();
    
    if (!string.IsNullOrEmpty(setting_.Name))
    {
        actions.Add((tt1, tt2) =>
        {
            if (tt1 != null && tt2 != null) 
                tt2.Rename(tt1, setting_.Name);
        });
    }
    
    if (setting_.Settings != null)
    {
        actions.Add((tt1, tt2) =>
        {
            if (tt1 != null && tt2 != null)
                tt2.ChangeSettings(tt1, setting_.Settings);
        });
    }
    
    if (setting_.Settings != null)
    {
        actions.Add((tt1, tt2) =>
        {
            if (tt1 != null && tt2 != null)
                tt2.ChangeLocation(tt1, setting_.Location);
        });
    }
    
    foreach (var item in itemCollection)
    {
        var tt1 = item.GetTT1();
        var tt2 = item.GetTT2();
        actions.ForEach(a => a(tt1, tt2));
    }
