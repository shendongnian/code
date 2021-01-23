    public class Group<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private TKey _key;
        private IEnumerable<TElement> _group;
        public Group(TKey key, IEnumerable<TElement> group)
        {
            _key = key;
            _group = group;
        }
        public TKey Key
        {
            get { return _key; }
        }
        public IEnumerator<TElement> GetEnumerator()
        {
            return _group.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
