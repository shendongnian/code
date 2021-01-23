    interface IPersisted<T> where T: IPersisted<T>
    {
        Expression<Func<T, bool>> Expression { get; }
    }
    class Repo<T> where T : IPersisted<T>, new()
    {
        public IQueryable<T> Get()
        {
            var dummy = new T();
            return _queryable.Where(dummy.Expression);
        }
    }
    class Deletable : IPersisted<Deletable>
    {
        public Deletable()
        {
        }
        public Expression<Func<Deletable, bool>> Expression
        {
            get { return x => !x.IsDeleted; }
        }
        bool IsDeleted { get; set; }
    }
