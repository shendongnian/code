    var firstGroup = Tiers.First();
    
    foreach(var item in firstGroup)
    {
      item.DoSomething();
    }
    
    // or using linq:
    firstGroup.Select(item => item.ToString());
    
    // or if you want to iterate over all items at once (kind of unwinds
    // the grouping):
    var itemNames = Tiers.SelectMany(g => g.ToString()).ToList();
