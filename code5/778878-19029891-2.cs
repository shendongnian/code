    class Repo<T> where T : IPersisted
    {
        IQueryable<T> Get()
        {
            if (typeof (T).IsAssignableFrom(typeof (IDeletable)))
            {
                return _queryable.Where(o => ((IDeletable) o).Deleted = false).AsQueryable();
            }
            return _queryable;
        }
    }
