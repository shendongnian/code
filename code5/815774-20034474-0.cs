    var query = from d in DateMonth
                group d by d into g
                select new {g.Key, Count = g.Count()};
    int MostAppearingMonthAmount = query.Max(g => g.Count);
    IEnumerable<string> MostAppearingMonth = query
                                          .Where(g => g.Count == MostAppearingMonthAmount)
                                          .Select(g => g.Key);
