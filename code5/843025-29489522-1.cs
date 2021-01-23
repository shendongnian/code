    public class EfContextProvider : IDbContextProvider
    {
        public EfContextProvider(YourContext context)
        {
            Context = context;
        }
        public YourContext Context { set; get; }
        public DbContextTransaction DbTransaction { set; get; }
        public void Commit()
        {
            DbTransaction.Commit();
        }
        public void Rollback()
        {
            DbTransaction.Rollback();
        }
        public void BeginTransaction()
        {
            DbTransaction=Context.Database.BeginTransaction();
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
