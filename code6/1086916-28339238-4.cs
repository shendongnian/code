    public interface IUnitOfWork
    {
        void SaveChanges();
    }
    public interface IRepository<TItem>
    {
        TItem GetByKey<TKey>();
        IQueryable<TItem> Query();
    }
