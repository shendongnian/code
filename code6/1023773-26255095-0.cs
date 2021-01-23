    private DbContext dbContext;
    private DbSet<TEntity> dbSet;
    public IQueryable<TEntity> All
    {
        get
        {
            return dbSet;
        }
    }
    public void InsertOrUpdate(TEntity entity)
    {
    }
