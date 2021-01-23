    protected readonly DbContext context;
        public Repository(DbContext datacontext)
        {
            DbSet = datacontext.Set<T>();
            context = datacontext;
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
