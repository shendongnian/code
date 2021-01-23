        public class GenericRepository<TContext, TEntity> 
            where TContext : DbContext
            where TEntity : class
        {
            internal TContext context;
            internal DbSet<TEntity> dbSet;
            public GenericRepository(TContext context)
            {
                this.context = context;
                this.dbSet = context.Set<TEntity>();
            }
     ...
