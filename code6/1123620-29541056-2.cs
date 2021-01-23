    using LinqKit;
    public static IQueryable<TEntity> Compare<TEntity>(IQueryable<TEntity> source, Expression<Func<TEntity, int>> func)
    {
        IQueryable<TEntity> res = source;
        if (!LBoundIsNull)
        {
            Expression<Func<TEntity, bool>> lambda = x => func.Invoke(x) >= _lBound;
            res = res.Where(lambda.Expand());
        }
        if (!UBoundIsNull)
        {
            Expression<Func<TEntity, bool>> lambda = x => func.Invoke(x) <= _uBound;
            res = res.Where(lambda.Expand());
        }
        return res;
    }
