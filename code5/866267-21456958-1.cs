    collection.SelectMany(d => d.Value)
              .OrderByDescending(r => r.Value.Entered)
              .GroupBy(rr => {rr.Value.Id1, rr.Value.Id2)
              .Select(g => new {
                   Id1 = g.Key.Id1,
                   Id2 = g.Key.Id2,
                   NewValue = g.FirstOrDefault(v => v.Status == "New").Value ?? 0,
                   OldValue = g.FirstOrDefault(v => v.Status == "Old").Value ?? 0,
                   Entered = g.Last().Entered
               })
