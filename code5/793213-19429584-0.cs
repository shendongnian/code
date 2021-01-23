    List<ChangeSet> changeSets = new List<ChangeSet>();
    //...
    var result = changeSets
        .SelectMany(c => c.WorkItems)
        .Distinct()
        .ToDictionary(w => w,
                    w => changeSets.Where(c => c.WorkItems.Contains(w)));
