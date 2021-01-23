    var dict = list.GroupBy(item => item.WinPct).ToDictionary(group => group.Key);
    foreach (var item in dict)
    {
        Console.Out.WriteLine("Key (winpct which is same for items): {0}", item.Key);
        foreach (var groupItem in item.Value)
        {
            Console.Out.WriteLine("GroupItem: {0} - {1}", groupItem.TeamId, groupItem.WinPct);
        }
    }
