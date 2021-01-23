    public interface IGenericRepository<TContext, TEntity>
        where TEntity : class, IEntity
        where TContext : IDbContext
    {
        TEntity NewEntity();
    }
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TContext, TEntity> 
        where TEntity : class, IEntity 
        where TContext : IDbContext
    {
        private readonly IDbContext _context;
        public GenericRepository(IUnitOfWork<TContext> uow)
        {
            _context = uow.Context;
        }
        public TEntity NewEntity()
        {
            var t = _context.Set<TEntity>().Create();
            _context.Set<TEntity>().Add(t);
            return t;
        }
    }
