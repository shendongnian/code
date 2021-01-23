    protected void SetOwnedCollectionMapping<T>(Expression<Func<TDataEntity, ICollection<T>>> mapping)
    {
        //
        // Hack to resolve the `OwnedCollection` extension method.
        //
        Expression<Func<IUpdateConfiguration<TDataEntity>, object>> template = 
            _ => _.OwnedCollection(mapping);
        var map = Expression.Parameter(
            typeof(IUpdateConfiguration<TDataEntity>),
            "map");
        graphMapping = Expression.Lambda<Func<IUpdateConfiguration<TDataEntity>, object>>(
            Expression.Call(
                ((MethodCallExpression)template.Body).Method,
                map,
                Expression.Quote(mapping)),
            map);
    }
