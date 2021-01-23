    public IQueryable<TEntity> Get<TEntity>(
        Action<IQueryConfig<TEntity>> options = null, 
        IEnumerable<Expression<Func<TEntity, Object>>> includeProperties = null) where TEntity : class, IEntity
    {
        this.AssertAccessible();
        IQueryable<TEntity> query = this.Context.Set<TEntity>();
        if ( includeProperties != null )
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        
        return this.ApplyOptions(query, options);
    }
