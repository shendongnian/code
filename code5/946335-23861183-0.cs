    var groups = numArray.GroupBy(v => v)
                    .OrderByDescending(g => g.Count())
                    .ToList();
    IEnumerable<int> modes = groups.TakeWhile(g => g.Count() == groups.First().Count())
                                   .Select(g => g.Key);
