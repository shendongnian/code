    public class Group<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private IEnumerable<TElement> elements;
        public Group(TKey key, IEnumerable<TElement> elements)
        {
            this.elements = elements;
            Key = key;
        }
        public TKey Key { get; private set; }
        public IEnumerator<TElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public static Group<TKey, TElement> CreateGroup<TKey, TElement>(
        TKey key, IEnumerable<TElement> elements)
    {
        return new Group<TKey, TElement>(key, elements);
    }
