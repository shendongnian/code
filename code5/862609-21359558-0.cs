    public class CacheDataContext : DataContext
    {
      public static string DBConnectionString = "Data Source=isostore:/Cache.sdf";
      public CacheDataContext(string connectionString)
            : base(connectionString) { }
      protected static readonly object OperationOnDatabaseUser = new object();
      public Table<User> UserItems;
    }
    public class CacheDataContextUser : CacheDataContext
    {
      public CacheDataContextUser(string connectionString)
        : base(connectionString) { }
      public User GetUser(string id)
      {
        lock (OperationOnDatabaseUser)
        {
            using (CacheDataContext context = new CacheDataContext(DBConnectionString))
            {
                //find user in the data base and return 
            }
        }
      }
    }
