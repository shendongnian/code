    public class MyDbContext : DbContext
    {
        /* some other constructors */
        public MyDbContext(string nameOrConnectionString, bool createDb)
            : base(nameOrConnectionString)
        {
            if(!createdDb)
            {
                System.Data.Entity.Database.SetInitializer<MyDbContext>(null);
            }
        }
    }
