    public IQueryable SelectProperty<TEntity>(DbContext context, string propertyName)
        where TEntity : class
    {
        var entities = context.Set<TEntity>();
        var query = entities.AsQueryable();
        var parameter = Expression.Parameter(typeof(TEntity), "instance");
        var propertyAccess = Expression.Property(parameter, propertyName);
        var projection = Expression.Lambda(propertyAccess, parameter);
        
        var selectExpression = Expression.Call(
            typeof(Queryable).GetMethods()
                             .First (x => x.Name == "Select")
                             .MakeGenericMethod(new[]{ typeof(TEntity), propertyAccess.Type }),
            query.Expression,
            projection);
                
        var distinctExpression = Expression.Call(
            typeof(Queryable).GetMethods()
                             .First (x => x.Name == "Distinct")
                             .MakeGenericMethod(new[]{ propertyAccess.Type }),
            selectExpression);
        
        var result = query.Provider.CreateQuery(distinctExpression);
        
        return result;
    }
