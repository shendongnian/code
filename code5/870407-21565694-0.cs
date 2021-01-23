    public class Factory<T> : IQueryable<T>
    {
        protected T[] _items = new T[]{};
        public Type ElementType
        {
            // or typeof(T)
            get { return _items.AsQueryable().ElementType; }
        }
        public System.Linq.Expressions.Expression Expression
        {
            get { return _items.AsQueryable().Expression; }
        }
        public IQueryProvider Provider
        {
            get { return _items.AsQueryable().Provider; }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ( IEnumerator<T> )_items.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
