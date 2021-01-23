    public class GenericTypeListDictionary
    {
        private readonly Dictionary<Type, object> _dictionaryOfLists = new Dictionary<Type, object>();
        public List<T> NewEntry<T>()
        {
            lock (typeof(List<T>))
            {
                var newList = new List<T>();
                _dictionaryOfLists.Add(typeof(T), newList);
                return newList;
            }
        }
        public List<T> GetEntry<T>()
        {
            object value;
            if (_dictionaryOfLists.TryGetValue(typeof(T), out value))
            {
                return (List<T>)value;
            }
            return null;
        }
        public void RemoveEntry<T>()
        {
            _dictionaryOfLists.Remove(typeof(T));
        }
    }
