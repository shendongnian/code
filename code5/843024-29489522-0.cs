    public interface IDbContextProvider
    {
        YourContext Context { get; set; }
        DbContextTransaction DbTransaction { get; set; }
        void Commit();
        void Rollback();
        void BeginTransaction();
        void SaveChanges();
    }
