    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression) 
    {
        if (IsTableEmpty())
        {
            return Enumerable.Empty<TEntity>().AsQueryable();
        }
        else
        {
            return _cloudTable.CreateQuery<TEntity>().AsQueryable().Where(expression);
        }
    }
