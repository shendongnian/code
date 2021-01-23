    public static IQueryable<TEntity> Compare<TEntity>(IQueryable<TEntity> source, Expression<Func<TEntity, int>> func)
    {
        IQueryable<TEntity> res = source;
        if (!LBoundIsNull) 
        {
            Expression ge = Expression.GreaterThanOrEqual(func.Body, Expression.Constant(_lBound));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(ge, func.Parameters);
            res = res.Where(lambda);
        }
        if (!UBoundIsNull)
        {
            Expression le = Expression.LessThanOrEqual(func.Body, Expression.Constant(_uBound));
            var lambda = Expression.Lambda<Func<TEntity, bool>>(le, func.Parameters);
            res = res.Where(lambda);
        }
        return res;
    }
