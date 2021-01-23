    public GenericMultipleRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
        accounts = new Lazy<GenericRepository<Account>>(() => { return dbContext; });
        accountsNotLazy = new GenericRepository<Account>(dbContext);
    }
