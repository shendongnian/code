    public interface ProductRepository
    {
        IQueryable<Product> Products { get; }
        void Add(Product model);
        void Remove(Product model);
    }
