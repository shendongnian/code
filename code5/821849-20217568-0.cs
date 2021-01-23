    public class MyDbContext : DbContext
    {
        public MyDbContext( string nameOrConnectionString ) 
            : base( nameOrConnectionString )
        {
        }
    }
