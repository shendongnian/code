    IQueryable<Product> query = products;
    bool firstOrderBy = true;
    foreach(var orderExpression in orderBy)
    {
        if (firstOrderBy)
        {
            query = query.OrderBy(orderExpression);
            firstOrderBy = false;
        }
        else
        {
            query = query.ThenBy(orderExpression);
        }
    }
