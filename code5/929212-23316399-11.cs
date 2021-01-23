    public interface IUnitOfWork
    {
        void Commit();
        IRepository<Store> Stores { get; }
        IRepository<Product> Products { get; }
    }
