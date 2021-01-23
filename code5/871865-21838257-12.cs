    public class ObjectSetWrapper<TEntity> : IQueryable<TEntity>, IQueryWrapper where TEntity : class
    {
        private IQueryable<TEntity> QueryableModel;
        private ObjectSet<TEntity> ObjectSet;
        public ObjectSetWrapper(ObjectSet<TEntity> objectSetModels)
        {
            this.QueryableModel = new QueryWrapper<TEntity>(objectSetModels);
            this.ObjectSet = objectSetModels;
        }
        public ObjectQuery<TEntity> Include(string path)
        {
            return this.ObjectSet.Include(path);
        }
        public void DeleteObject(TEntity @object)
        {
            this.ObjectSet.DeleteObject(@object);
        }
        public void AddObject(TEntity @object)
        {
            this.ObjectSet.AddObject(@object);
        }
        public IEnumerator<TEntity> GetEnumerator()
        {
            return QueryableModel.GetEnumerator();
        }
        public Type ElementType
        {
            get { return typeof(TEntity); }
        }
        public System.Linq.Expressions.Expression Expression
        {
            get { return this.QueryableModel.Expression; }
        }
        public IQueryProvider Provider
        {
            get { return this.QueryableModel.Provider; }
        }
        public void Attach(TEntity entity)
        {
            this.ObjectSet.Attach(entity);
        }
        public void Detach(TEntity entity)
        {
            this.ObjectSet.Detach(entity);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.QueryableModel.GetEnumerator();
        }
        IQueryable IQueryWrapper.UnderlyingQueryable
        {
            get { return this.ObjectSet; }
        }
    }
