     public class SqlUnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private ApplicationDbContext _db;
        public SqlUnitOfWork(ApplicationDbContext context)
        {
            _db = context;
        }
        public IRepository<T> Repistory
        {
            get
            {
                return new SqlRepository<T>(_db);
            }
        }
        public int Commit()
        {
            return _db.SaveChanges();
        }
        public Task<int> CommitAsync()
        {
            return _db.SaveChangesAsync();
        }
        public object GetContext()
        {
            return this._db;
        }
        public IRepository<TEntity> GetTypeRepository<TEntity>() where TEntity : class, IEntity
        {
            return new SqlRepository<TEntity>(_db);
        }
    }
