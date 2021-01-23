    var dim = 2;
    var tuples = num2.GroupBy(a => a[0])
        .Select(g => new Tuple<int[], List<int[]>>(new [] { g.Count(), g.Key }, g.Select(a => a.Skip(1).ToArray()).ToList()))
        .ToList();
    for (int n = 1; n < dim; n++)
    {
        tuples = tuples.SelectMany(t => t.Item2.GroupBy(list => list[0])
            .Select(g => new Tuple<int[], List<int[]>>(new[] { g.Count() }.Concat(t.Item1.Skip(1)).Concat(new [] { g.Key }).ToArray(), g.Select(a => a.Skip(1).ToArray()).ToList())))
            .ToList();
    }
    var output = tuples.Select(t => new { Arr = string.Join(",", t.Item1.Skip(1)), Count = t.Item1[0] })
        .OrderByDescending(o => o.Count)
        .ToList();
