    foreach (IGrouping<DateTime, DateTime> item in groups)
    {
        var common  =   initialGroups
                        .GroupBy(grp => {
                                var c = CalculateArg(grp.a.Arg);
                                return (c == item.Key && grp.b.Arg == someId) ? 1 :
                                        c == item.Key ? 2 : 3;
                                })
                        .OrderBy(g=>g.Key)
                        .Select(g=>g.Sum(c=>c.Value)).ToList();
        var countMatchId = common[0];
        var countAll = common[0] + common[1];
    }
