    var result = data
        .Where(t => t.DivisionID != 0)
        .GroupBy(t => t.DivisionID)
        .Select(g => new MyEntity
        {
            TotalSales = g.Sum(n => n.TotalSales) - g.Average(n => n.TotalSales),
            TotalPurchases = g.Sum(n => n.TotalPurchases) - g.Average(n => n.TotalPurchases)
        })
        .GroupBy(t => 0) // create single group
        .Select(g => new MyEntity
        {
            TotalSales = -g.Sum(t => t.TotalSales),
            TotalPurchases = -g.Sum(t => t.TotalPurchases)
        })
        .SingleOrDefault();
