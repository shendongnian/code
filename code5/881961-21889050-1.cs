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
