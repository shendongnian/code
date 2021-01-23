    public class MemoryDbSet<TEntity> : DbSet<TEntity>, IQueryable,
        IEnumerable<TEntity>, IDbAsyncEnumerable<TEntity>
        where TEntity : class
    {
        private readonly Func<TEntity, object[], bool> _findSelector;
        private readonly ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;
        public MemoryDbSet(Func<TEntity, object[], bool> findSelector)
        {
            _findSelector = findSelector;
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }
        public override TEntity Find(params object[] keyValues)
        {
            return _data.SingleOrDefault(item => _findSelector(item, keyValues));
        }
        public override TEntity Add(TEntity item)
        {
            _data.Add(item);
            return item;
        }
        public override TEntity Remove(TEntity item)
        {
            _data.Remove(item);
            return item;
        }
        public override TEntity Attach(TEntity item)
        {
            _data.Add(item);
            return item;
        }
        public override TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }
        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
        public override ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }
        Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }
        Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }
        IQueryProvider IQueryable.Provider
        {
            get
            {
                return new MemoryDbAsyncQueryProvider<TEntity>(_query.Provider);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IDbAsyncEnumerator<TEntity> IDbAsyncEnumerable<TEntity>.
            GetAsyncEnumerator()
        {
            return new MemoryDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }
    }
