    var groups = list.GroupBy(x => x).ToList();
    var count = groups.Max(g => g.Count());
    var items = groups.Where(g => g.Count() == count)
                      .Select(g => g.Key)
                      .ToList();
