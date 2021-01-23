    double GetAvailableBalance(DbProxy dbProxy, DateTimeOffset atTime)
    {
        return await dbProxy.Transactions
            .Where(t => t.DateAvailable <= atTime)
            .Select(t => t.AmountInCents / 100d)
            .DefaultIfEmpty()
            .SumAsync();
    }
    double GetAvailableBalance(DbProxy dbProxy, DateTimeOffset atTime)
    {
        return await dbProxy.Transactions
            .Where(t => t.DateAvailable <= atTime)
            .Select(t => t.AmountInCents / 100d)
            .Concat(new[] { 0 })
            .SumAsync();
    }
