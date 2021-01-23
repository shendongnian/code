    public IQueryable<TEntity> Including(params Expression<Func<TEntity, object>>[] _includeProperties)
    {
        IQueryable<TEntity> query = m_context.Set<TEntity>();
        return _includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
