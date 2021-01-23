    public IQueryable<TEntity> SearchForIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
    {
            IQueryable<TEntity> query = dbSet;
            if (includeProperties != null)
            {
                foreach (var includedProperty in includeProperties)
                {
                    query.Include(includedProperty).Load();
                }
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            return query;
    }
