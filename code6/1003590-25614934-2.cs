    public class Repository<T> where T : class
    {
        private readonly DbSet<T> _queryableBase;
        public Repository(DbSet<T> queryableBase)
        {
            _queryableBase = queryableBase;
        }
        public T Select(IFilter<T> filterClass)
        {
            return filterClass.Filter(_queryableBase.AsQueryable()).First();
        }
        public IEnumerable<T> SelectMany(IFilter<T> filterClass)
        {
            return filterClass.Filter(_queryableBase.AsQueryable());
        }
        public void Delete(T item)
        {
            _queryableBase.Remove(item);
        }
        public void Add(T item)
        {
            _queryableBase.Add(item);
        }
    }
