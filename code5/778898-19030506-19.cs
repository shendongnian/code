    interface IPersisted<T> where T: IPersisted<T>
    {
        Expression<Func<T, bool>> Predicate { get; }
    }
    class Repo<T> where T : IPersisted<T>, new()
    {
        public IQueryable<T> Get()
        {
            var dummy = new T();
            return _queryable.Where(dummy.Predicate);
        }
    }
    class Deletable : IPersisted<Deletable>
    {
        public Deletable()
        {
        }
        public Expression<Func<Deletable, bool>> Predicate
        {
            get { return x => !x.IsDeleted; }
        }
        bool IsDeleted { get; set; }
    }
