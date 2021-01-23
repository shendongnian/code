    public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties) 
    {
       IQueryable<TEntity> queryable = GetAll();
       foreach (Expression<Func<TEntity, object>> includeProperty in includeProperties) 
       {
          queryable = queryable.Include<TEntity, object>(includeProperty);
       }
       
       return queryable;
    }
