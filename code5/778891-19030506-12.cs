    interface IPersisted
    {
        Expression<Func<T, bool>> GetPredicate<T>() where T : IPersisted;
    }
    class Repo<T> where T : IPersisted<T>
    {
        public IQueryable<T> Get()
        {
            return _queryable.Where(dummy.GetPredicate<T>());
        }
    }
    class Deletable : IPersisted
    {
        Expression<Func<T, bool>> IPersisted.GetExpression<T>() //made it explicit
        {
            return x => ((Deletable)(object)x).IsDeleted;
        }
    }
