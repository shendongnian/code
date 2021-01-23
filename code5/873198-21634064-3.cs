    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private readonly Dictionary<Type, object> _repos;
        public IRepository<T> GetRepository<T>() {
            if (_repos.ContainsKey(typeof (T)))
                return _repos[typeof (T)] as IRepository<T>;
            var repo = new Repository(_context);
            _repos.Add(typeof (T), repo);
            return repo;
        }
        public int SaveChanges() {
            return _context.SaveChanges();
        }
        dispose stuff - make sure to dispose your context
    }
