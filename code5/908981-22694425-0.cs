    public class YourContext : DbContext
    {
        public DatabaseContext(string connectionStringName)
          : base(connectionStringName)
        {
        }
    }
