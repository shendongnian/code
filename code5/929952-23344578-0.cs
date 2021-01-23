    public class KeyedSynchronizer<TKey>
    {
        private ConcurrentDictionary<TKey, Lazy<Task>> dictionary;
        public KeyedSynchronizer(IEqualityComparer<TKey> comparer = null)
        {
            dictionary = new ConcurrentDictionary<TKey, Lazy<Task>>(
                comparer ?? EqualityComparer<TKey>.Default);
        }
        public Task ActOnKey(TKey key, Action action)
        {
            var dictionaryValue = dictionary.AddOrUpdate(key,
                new Lazy<Task>(() => Task.Run(action)),
                    (_, task) => new Lazy<Task>(() =>
                        task.Value.ContinueWith(t => action())));
            return dictionaryValue.Value;
        }
        public static readonly KeyedSynchronizer<TKey> Default =
            new KeyedSynchronizer<TKey>();
    }
