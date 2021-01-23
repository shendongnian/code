    var sortedQueryable = query as IOrderedQueryable<Person>;
    if (sortedQueryable != null)
    {
        query = sortedQueryable.ThenBy(o => o.Forename);
    }
    else
    {
        query = query.OrderBy(o => o.Forename);
    }
