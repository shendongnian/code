    public MyRepository(DbContext dbContext)
    {
        if (dbContext == null) 
            throw new ArgumentNullException("Null DbContext");
        this.DbContext = dbContext;
        this.DbSet = this.DbContext.Set<T>();
    }
