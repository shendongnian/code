    var grouped = allData.GroupBy(x => x[0])
                         .Select(g => new
                         {
                             Name = g.Key,
                             Sum = g.Sum(x => int.Parse(x[2]))
                         });
