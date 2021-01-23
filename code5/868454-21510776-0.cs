    public interface IRepository
    {
        ...
        IQueryable<T> Query<T>();
    }
