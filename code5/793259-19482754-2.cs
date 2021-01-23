    public class MyDbContext : MyDbContextBase
    {
      public MyDbContext(string connectionStringOrName, IDatabaseInitializer<MyDbContext> dbInitializer) 
        : base(connectionStringOrName)
      {
      }
    }
    
    public class MyTestDbContext : MyDbContextBase
    {
      public MyTestDbContext(string connectionStringOrName, IDatabaseInitializer<MyDbContext> dbInitializer) 
        : base(connectionStringOrName)
      {
        Database.SetInitializer(dbInitializer);
      }
    }
