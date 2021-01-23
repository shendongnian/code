    var grouped = list.GroupBy(t => t.Item1)
                      .Where(g => g.Count() > 1)
                      .Select(g => Tuple.Create(g.Key, g.Aggregate( (i,j) => i.Item2 * j.Item2))
                      .ToList();
    var total = grouped.Sum(i => i.Item2);
