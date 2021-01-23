    var calculated = initialGroups
      .Select(group => new { Group = group, Arg = CalculateArg(group.a.Arg) })
      .ToList();
    var sumCollection = groups
      .GroupJoin(calculated,
                 item => item.Key,
                 group => group.Arg,
          (group, calculatedCollection) =>
             new {
                Group = group,
                SumAll = calculatedCollection.Sum(y => y.Group.c.Value),
                SumMatchId = calculatedCollection
                             .Where(y => y.Group.b.Arg == someId)
                             .Sum(y => y.Group.c.Value)
             });
    foreach (var item in sumCollection)
    {
        item.SumAll     // you get the idea
        item.SumMatchId // 
    }
