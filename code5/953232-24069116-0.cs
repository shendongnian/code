    public void Add()
    {
        object obj = this;
        this._dbContext.Set<TEntity>().Add((TEntity)obj);
        this._dbContext.SaveChanges();
    }
