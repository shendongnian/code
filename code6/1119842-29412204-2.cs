    var group = project.Group(
        key => new { key.Month, key.Product },
        g => new
        {
             MonthAndProduct = g.Key,
             TotalSales = g.Sum(o => o.Value)
        });
