    public class Repository
    {
        private class RepositoryKey
        {
            public RepositoryKey(Type type, string key)
            {
                this.Type = type;
                this.Key = key;
            }
            public Type Type { get; private set; }
            public string Key { get; private set; }
            //TODO: override Equals and GetHashCode.
        }
        private Dictionary<RepositoryKey, object> _dict =
                                                  new Dictionary<RepositoryKey, object>();
        public void Add<T>(string key, T obj)
        {
            _dict.Add(new RepositoryKey(typeof(T), key), obj);
        }
        public Get<T>(string key)
        {
            return (T)_dict[new RepositoryKey(typeof(T), key)];
        }
    }
