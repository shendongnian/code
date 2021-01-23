    interface IPersisted
    {
        Expression<Func<T, bool>> GetPredicate<T>() where T : IPersisted;
    }
    class Repo<T> where T : IPersisted
    {
        public IQueryable<T> Get()
        {
            return _queryable.Where(dummy.GetPredicate<T>());
        }
    }
    class Deletable : IPersisted
    {
        Expression<Func<T, bool>> IPersisted.GetPredicate<T>() //made it explicit
        {
            return x => ((Deletable)(object)x).IsDeleted;
        }
    }
