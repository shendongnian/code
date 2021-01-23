    var query = this.dbContext.Customers;
    if (!string.IsNullOrEmpty(sortFilterName))
    {
        query = query.Where(q => q.Name.Equals(sortFilterName));
    }
    if (!string.IsNullOrEmpty(sortFilterAddress))
    {
        query = query.Where(q => q.Adress.Equals(sortFilterAddress));
    }
    return query.ToList();
