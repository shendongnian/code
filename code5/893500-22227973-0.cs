    public List<Order> GetOrders(params Expression<Func<Order, object>>[] selectors)
    {
        var dbQuery = GetQuery();
        if (selectors.Any())
        {
            var orderedQuery = dbQuery.OrderBy(selectors.First());
            foreach (var selector in selectors.Skip(1))
                orderedQuery = orderedQuery.ThenBy(selector);
            dbQuery = orderedQuery;
        }
        return dbQuery.ToList();
    }
