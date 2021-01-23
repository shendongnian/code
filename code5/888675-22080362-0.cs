    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] navigationProperties)
    {
        var ReturnSetQueryable = _EntityObjectSet.Where(expression);
        return ReturnSetQueryable.AsQueryable();
    }
