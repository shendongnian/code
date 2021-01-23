    private IDbContext dbContext; // this was already here
  
    public T GetDbContext<T>() where T : DbContext, IDbContext
    {
       return this.dbContext as T;
    }
