    // DbContext needs additional constructor:
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbConnection connection) 
            : base(connection, true)
        {
        }
    }
    // Usage:
    DbConnection connection = Effort.DbConnectionFactory.CreateTransient();    
    MyDbContext context = new MyDbContext(connection);
