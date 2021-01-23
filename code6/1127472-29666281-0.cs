    public IEnumerable<IEnumerable<Bar>> GroupIntoMonths(IEnumerable<Bar> bars)
    {
        return bars.GroupBy(c => new { c.StockDate.Year, c.StockDate.Month })
                   .OrderByDescending(c => c.Key.Year)
                   .ThenByDescending(c => c.Key.Month);
    }
