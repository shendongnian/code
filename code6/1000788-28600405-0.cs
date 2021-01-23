     public DatabaseContext() : base("DatabaseContext")
     {
        InitializeDatabase();
     }
     public DatabaseContext(string connectionString) : base(connectionString)
     {
         Database.Connection.ConnectionString = connectionString;
         InitializeDatabase();
     }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
         modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
     }
