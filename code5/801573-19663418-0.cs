    public class TestDbSet<TEntity> : DbSet<TEntity>, IQueryable, IEnumerable<TEntity>
        where TEntity : class
    {
        ObservableCollection<TEntity> _data;
        IQueryable _query;
        public TestDbSet()
        {
            _data = new ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
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
            get
            {
                return _data;
            }
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
            get { return _query.Provider; }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
    }
