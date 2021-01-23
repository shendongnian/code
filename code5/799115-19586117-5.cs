    var result = data
        .Where(t => t.DivisionID != 0)
        .GroupBy(t => t.DivisionID)
        .Select(g => new MyEntity
        {
            TotalSales = g.Skip(1).Sum(n => n.TotalSales),
            TotalPurchases = g.Skip(1).Sum(n => n.TotalPurchases)
        })
        .Aggregate(new MyEntity(), (t1, t2) => new MyEntity
        {
            TotalSales = t1.TotalSales - t2.TotalSales,
            TotalPurchases = t1.TotalPurchases - t2.TotalPurchases,
        });
    var result = data
        .Where(t => t.DivisionID != 0)
        .GroupBy(t => t.DivisionID)
        .Select(g => new MyEntity
        {
            TotalSales = g.Skip(1).Sum(n => n.TotalSales),
            TotalPurchases = g.Skip(1).Sum(n => n.TotalPurchases)
        })
        .GroupBy(t => 0) // create single group
        .Select(g => new MyEntity
        {
            TotalSales = -g.Sum(t => t.TotalSales),
            TotalPurchases = -g.Sum(t => t.TotalPurchases)
        })
        .SingleOrDefault();
