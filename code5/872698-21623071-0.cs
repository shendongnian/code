    class Lookup<TKey, TValue, TKeyCollection, TValueCollection>
        where TKeyCollection : ICollection<TKey>
        where TValueCollection : ICollection<TValue>
    {
        public TKeyCollection _KeyCollection;
        public TValueCollection _ValueCollection;
    }
