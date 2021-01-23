    var propertyTotalsByStatus =
        query.GroupBy(p => p.Status)
             .OrderByDescending(p => p.Count())
             .Select(pg => new { Status = pg.FirstOrDefault().Status.Name, Count = pg.Count() })
             .ToList()
             .Select(x => new object[] { x.Status, x.Count })
             .ToList();
           
