    internal virtual IQueryable<TEntity> BuildQuery(Expression<Func<TEntity,bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
            {
                IQueryable<TEntity> query = this.context.IsReadOnly ? dbSet.AsNoTracking() : dbSet;
                foreach (var include in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include);
                }
    
                if (filter != null)
                    query = query.Where(filter);
    
                if (orderBy != null)
                    return orderBy(query);
                    
                return query;
            }
