    var propertyTotalsByStatus =
        query.GroupBy(p => p.Status)
             .OrderByDescending(p => p.Count())
             .Select(pg => new object[] { pg.FirstOrDefault().Status.Name, pg.Count() })
             .ToList();
