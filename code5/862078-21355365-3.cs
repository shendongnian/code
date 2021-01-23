    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    
        void Save();
    }
    
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IDbContext, new()
    {
        private readonly IDbContext _ctx;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;
    
        public UnitOfWork()
        {
            _ctx = new TContext();
            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }
    
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }
            var repository = new Repository<TEntity>(_ctx);
   
            _repositories.Add(typeof(TEntity), repository);
    
            return repository;
        }
    
        public void Save()
        {
            _ctx.SaveChanges();
        }
    
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
    
            if (disposing)
            {
                _ctx.Dispose();
            }
    
            this._disposed = true;
        }
    } 
