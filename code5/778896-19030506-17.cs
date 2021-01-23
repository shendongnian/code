    interface IPersisted
    {
        Expression<Func<object, bool>> Predicate { get; }
    }
    class Repo<T> where T : IPersisted<T>
    {
        public IQueryable<T> Get()
        {
            return _queryable.Where(dummy.Predicate);
        }
    }
    class Deletable : IPersisted
    {
        public Expression<Func<object, bool>> Predicate
        {
            get { return x => !((Deletable)x).IsDeleted; }
        }
    }
