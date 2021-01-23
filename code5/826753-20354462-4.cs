    public class MYDbContext : DbContext {
         // MIgration parameterless constructor is managed in  MyMigrationsContextFactory 
         
        public MyDbContext(string connectionName) : base(connectionName) { } // no this
        public MYDbContext(DbConnection dbConnection, bool contextOwnsConnection)  // THIS ONE
            : base(dbConnection, contextOwnsConnection) {  }
     
