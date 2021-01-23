    // you may or may not want to have the constraint here
    public interface ICatalogRepository<T> where T : DbSet
    {
        // sensor methods
        void Add(T entity);
        void Update(T entity);
    }
