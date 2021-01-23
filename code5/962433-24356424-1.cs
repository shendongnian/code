    static void Main(string[] args)
    {
        DbConfiguration.Loaded += DbConfiguration_Loaded;
    
        using (var db = new TransactionHandlerDemoEntities()) {
            var handler = db.TransactionHandler;
    
            db.AddToDemoTable(new DemoTable { Name = "TestEntiry1" });
            db.SaveChanges();
        }
    }
    
    static void DbConfiguration_Loaded(object sender, DbConfigurationLoadedEventArgs e)
    {
        e.AddDependencyResolver(new TransactionHandlerResolver(
            () => new CommitFailureHandler(),
            SqlProviderServices.ProviderInvariantName,
            null),true);
    }
