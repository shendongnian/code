    public abstract class Repository<TContext, TEntity> : IRepository<TContext, TSet>
        where TContext : DbContext
        where TEntity : class
    {
        private TContext context;
        private readonly IDbSet<TEntity>;
        // ...
    }
