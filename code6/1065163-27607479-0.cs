    public static TEntity ExecuteMagicSetter<TEntity, TProperty>(
            this TEntity obj,
            Expression<Func<TEntity, TProperty>> selector,
            TProperty value)
    {
        var setterExpr = CreateSetter(selector);
        setterExpr.Compile()(obj, value);
        return obj;
    }
    
    private static Expression<Action<TEntity, TProperty>> CreateSetter<TEntity, TProperty>
            (Expression<Func<TEntity, TProperty>> selector)
    {
        var valueParam = Expression.Parameter(typeof(TProperty));
        var body = Expression.Assign(selector.Body, valueParam);
        return Expression.Lambda<Action<TEntity, TProperty>>(body,
            selector.Parameters.Single(),
            valueParam);
    }
