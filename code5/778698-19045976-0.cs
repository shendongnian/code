    class Parameter
    {
        public virtual Entity Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
    
    ICriteria filter;
    foreach(var param in parameterList)
    {
        var crit = Expression.And(Expression.Eq("Name", param.Name), Expression.Eq("Value", param.Value);
        filter = (filter == null) ? crit : Expression.Or(filter, crit);
    }
    var subquery = QueryOver.Of<Parameter>()
        .Where(filter)
        .Select(Projections.Group("Parent.Id"));
        .Where(Restrictions.Eq(Projections.Count<Parameter>(p => p.Id), parameterList.Count));
    var results = QueryOver.Of<Entity>()
        .WuithSubquery.WhereProperty(e => e.Id).IsIn(subquery)
        .List();
