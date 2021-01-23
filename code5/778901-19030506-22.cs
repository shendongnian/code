    interface IPersisted<T> where T: IPersisted<T>
    {
        Func<T, bool> Predicate { get; }
    }
    class Repo<T> where T : IPersisted<T>
    {
        public IQueryable<T> Get()
        {
            return _queryable.Where(x => x.Predicate(x));
        }
    }
    class Deletable : IPersisted<Deletable>
    {
        public Func<Deletable, bool> Predicate
        {
            get { return x => !x.IsDeleted; }
        }
    }
