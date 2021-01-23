    public class Repository<T> : IRepository<T>
        where T : class
    {
        ...
        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }
    }
