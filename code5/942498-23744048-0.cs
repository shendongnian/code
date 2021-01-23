    List<TargetType> targetTypeList = new List<TargetType>();
    List<IGrouping<string, OriginialType>> grouping = orignialList.GroupBy(o => o.Module).ToList();
    
    foreach(IGrouping<string, OriginialType> group in grouping)
    {
        TargetType newItem = new TargetType() { Module = group.Key, Screen = new List<Screen>() };                
                    
        foreach(OriginialType o in group)
            newItem.Screen.Add(new Screen() { ScreenName = o.Screen, Permission = o.Permission });   
    
        targetTypeList.Add(newItem);
    }
