    public interface IQueryResult<out T> : IEnumerable<T>, IListSource
    {    
    }
    internal class QueryResultWrapper<T> : IQueryResult<T>
    {
        private readonly DbRawSqlQuery<T> _source;
        public QueryResultWrapper(DbRawSqlQuery<T> source)
        {
            _source = source;
        }
        public bool ContainsListCollection
        {
            get { return ((IListSource)_source).ContainsListCollection; }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_source).GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _source.GetEnumerator();
        }
        public IList GetList()
        {
            return ((IListSource)_source).GetList();
        }
    }
