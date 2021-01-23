    public IEnumerable<TEntity> GetAll(string[] includes)
    {
        var query = this.dbEntitySet;
    
        foreach (var include in includes)
            query = query.Include(include);
    
        return query;
    }
