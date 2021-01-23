        class Repository<T> : IRepository<T>
        where T : INameable
    {
        Dictionary<string, object> values = new Dictionary<string, object>();
        void AddValue(INameable o)
        {
            values.Add(o.Name, o);
        }
        public void Add(T obj)
        {
            AddValue(obj);
        }
        public IEnumerable<T> Values
        {
            get { return values.Values.OfType<T>(); }
        }
    }
    class UnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public IRepository<T> GetRepository<T>()
            where T : INameable
        {
            object repository;
            if (!_repositories.TryGetValue(typeof (T), out repository))
            {
                repository = new Repository<T>();
                _repositories[typeof (T)] = repository;
            }
            return (IRepository<T>)repository;
        }
    }
