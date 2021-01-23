    var result = data
        .Where(t => t.DivisionID != 0)
        .GroupBy(t => t.DivisionID)
        .Select(g => new MyEntity
        {
            TotalSales = g.Sum(n => n.TotalSales) - g.Average(n => n.TotalSales),
            TotalPurchases = g.Sum(n => n.TotalPurchases) - g.Average(n => n.TotalPurchases)
        })
        .Aggregate(new MyEntity(), (t1, t2) => new MyEntity
        {
            TotalSales = t1.TotalSales - t2.TotalSales,
            TotalPurchases = t1.TotalPurchases - t2.TotalPurchases,
        });
