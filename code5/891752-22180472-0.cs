    sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly TKey m_key;
        private readonly IEnumerable<TElement> m_elements;
        public Grouping(TKey key, IEnumerable<TElement> elements)
        {
            if (elements == null)
                throw new ArgumentNullException("elements");
            m_key = key;
            m_elements = elements;
        }
        public TKey Key
        {
            get { return m_key; }
        }
        public IEnumerator<TElement> GetEnumerator()
        {
            return m_elements.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
