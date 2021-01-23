    var result = from i in input
                 groupby new { i.Company, i.Year, i.Month } into g
                 select new {
                     g.Key.Company,
                     g.Key.Year,
                     g.Key.Month,
                     Version = g.Select(x => x.Version).Last()
                 };
