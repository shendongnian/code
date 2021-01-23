    public interface IUnitOfWork : IDisposable
    {
       void Save();    
       IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;    
       TContext GetDbContext<TContext>() where TContext : DbContext, IDbContext;
    }
