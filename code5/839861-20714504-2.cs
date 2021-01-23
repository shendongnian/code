    var lists = list.Select(c => c.A)
                    .Concat(list.Select(c => c.B))
                    .Concat(list.Select(c => c.C))
                    .Select((v, i) => new { Index = i, Object = v})
                    .GroupBy(g => g.Index / list.Count, g => g.Object, (k,v) => v.ToArray())
                    .ToList();
