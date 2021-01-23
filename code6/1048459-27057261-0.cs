    var userLookup = orderList.ToLookup(o => o.UserId);
    int maxOrders = userLookup.Max(x => x.Count());
    int minOrders = userLookup.Min(x => x.Count());
    int avgOrders = (int)userLookup.Average(x => x.Count());
    IEnumerable<string> allUserIDsWithMaxOrders = userLookup
        .Where(x => x.Count() == maxOrders)
        .Select(g => g.Key);
    IEnumerable<string> allUserIDsWithMinOrders = userLookup
        .Where(x => x.Count() == minOrders)
        .Select(g => g.Key);
    IEnumerable<string> allUserIDsWithAvgOrders = userLookup
        .Where(x => x.Count() == avgOrders)
        .Select(g => g.Key);
