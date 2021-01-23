    public class Repository<T> where T : EntityObject
    {
        public Repository(YourDBContext context) {
            _context = context;
            if(_context != null)
            {
                _dbSet = _context.Set<T>();
            }
        }
        
        /* add methods for insert, update, delete, etc... */
        private YourDBContext _context;
        private DBSet<T> _dbSet;
    }
