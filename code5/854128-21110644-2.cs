    //manage the queries with OR clause first
    var innerOr = Predicate.True<database_BWICs>();//or the real type of your entity
    
    if (!String.IsNullOrEmpty(query.id1))
    {
        var ids = query.id1.Split(',');
        innerOr = innerOr.Or(c => c.ID1!= null && ids.Contains(c.ID1));
    }
    if (!String.IsNullOrEmpty(query.id2))
    {
        var ids = query.id2.Split(',');
        innerOr = innerOr.Or(c => c.ID2!= null && ids.Contains(c.ID2));
    }
    //now manage the queries with AND clauses
    var innerAnd = Predicate.True<database_BWICs>();//or the real type of your entity
    
    if (query.price_type != null)
    {
        var ids = query.price_type.Split(',');
        innerAnd = innerAnd.And(c => ids.Contains(c.Type));
    }
    //etc.
    
    innerAnd = innerAnd.And(innerOr);
    
    var data = db.database_BWICs.AsQueryable().Where(innerAnd);
        
