    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext, new()
    {
        private IDbContext dbContext;
      
        public UnitOfWork()
        {
            this.dbContext = new TContext();
        }
    
        public T GetDbContext<T>() where T : DbContext, IDbContext
        {
            return this.dbContext as T;
        }
        ...
    }
