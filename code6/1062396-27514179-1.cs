    var grouped = list.GroupBy(t => t.Item1)
                  .Where(g => g.Count() > 1)
                  .Select(g => Tuple.Create(g.Key, g.Skip(1).Aggregate(g.First().Item2, (i,j) => i*j.Item2)))
                  .ToList();
    var total = grouped.Sum(i => i.Item2);
