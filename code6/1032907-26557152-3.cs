    public class NongenericBaseList : IEnumerable  // Without the T!
    {
        protected List<BaseItem> _items;
        // The property
        public IEnumerable<BaseItem> L
        {
            get { return this as IEnumerable<BaseItem>; }
        }
        public BaseItem this[int index]
        {
            get { return _items[index]; }
        }
        public IEnumerator<BaseItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
