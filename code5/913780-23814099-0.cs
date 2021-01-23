    private void InsertOrUpdate(IQueryable<CccPricingPricedDays> source, Table<CccPricingPricedDays> target)
    {
        Expression<Func<CccPricingPricedDays,CccPricingPricedDays, bool>> expression = (s,t) => t.DayEnd == s.DayEnd && t.DayStart == s.DayStart;
        source
              .AsExpandable()
              .Where(s => !target.Any(expression(s, t)))
              .Insert(target, table => table);
    }
