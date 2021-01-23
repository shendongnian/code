    public IEnumerable<TEntity> GetAll(string[] includes)
    {
         IQueryable<T> query = this.dbEntitySet;
         foreach (var include in includes)
             query = query.Include(include);
        return query;
    }
