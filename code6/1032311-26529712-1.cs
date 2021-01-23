    public static class CuttedGroup
    {
        public static IGrouping<TKey, TElement> Create<TKey, TElement>(IGrouping<TKey, TElement> source, int maximumElements)
        {
            return new CuttedGroup<TKey, TElement>(source, maximumElements);
        }
    }
    public class CuttedGroup<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private IGrouping<TKey, TElement> _Source;
        private int _MaximumElements;
        public CuttedGroup(IGrouping<TKey, TElement> source, int maximumElements)
        {
            // Parameter check omitted...
            _Source = source;
            _MaximumElements = maximumElements;
        }
        public TKey Key
        {
            get { return _Source.Key; }
        }
        public IEnumerator<TElement> GetEnumerator()
        {
            return _Source.Take(_MaximumElements).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
