    public IQueryable<TEntity> SearchForIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
            IQueryable<TEntity> query = dbSet;
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            return query;
    }
