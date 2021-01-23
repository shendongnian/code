    public object Get(FindCustomers request)
    {
        var customers = new List<Customer>();
        var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<Customer>();
        ev.Where(c => c.LastName == request.LastName).And(c => c.Age == request.Age);
        AddOptionalFilters(ev, request);
        customers = Db.Select<Customer>(ev);
        return customers;
    }
    private void AddOptionalFilters(SqlExpressionVisitor<Customer> expressionVisitor, FindCustomers request)
    {
        if (request.City.HasValue)
        { expressionVisitor.Where(c => c.City == request.City); }
        if (request.ZipCode.HasValue)
        { expressionVisitor.Where(c => c.ZipCode == request.ZipCode); }
    } 
