    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbSet;
        public Repository(IDbContext context) {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T entity) {
            _dbSet.Add(entity);
        }
        public void Update(T entity) {
            _context.Entry(entity).State = EntityState.Modified;
        }
        ...
    }
