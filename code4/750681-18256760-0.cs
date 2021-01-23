    public class HeadersWrapper : IQueryable<Header>
    {
        private readonly IQueryable<Header> _queryableSource;
        public HeadersWrapper(IEnumerable<Header> source)
        {
            _queryableSource = source.AsQueryable();
        }
        public IEnumerator<Header> GetEnumerator()
        {
            return _queryableSource.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Expression Expression
        {
            get { return _queryableSource.Expression; }
        }
        public Type ElementType
        {
            get { return _queryableSource.ElementType; }
        }
        public IQueryProvider Provider
        {
            get { return _queryableSource.Provider; }
        }
    }
