    public class MyDbContext : DbContext, IUnitOfWork
    {
        public MyDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }
