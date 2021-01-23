    public class DatabaseContext : DbContext
    {
        // Add this constructor to your database context
        public DatabaseContext() : base()
        {
            AppData.Set();
        }
        // DbSet's are defined here
    }
