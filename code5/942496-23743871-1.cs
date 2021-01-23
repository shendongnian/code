    List<TargetType> targetList = new List<TargetList>();
    foreach (var grouping in originalList.GroupBy(o => o.Module))
    {
        TargetType target = new TargetType { Module = grouping.Key };
        targetList.Add(target);
        target.Screen = grouping.Select(o => new Screen
           {
              ScreenName = o.Screen,
              Permission = o.Permission
           }).ToList();
    }
