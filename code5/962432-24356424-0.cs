    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetTransactionHandler(SqlProviderServices.ProviderInvariantName, 
                () => new CommitFailureHandler());
        }
    }
        
    public class TestContext : DbContext { }
    
    static void Main(string[] args)
    {
        // instantiate DbContext to initialize code based configuration
        using (var db = new TestContext()) { }
        
        using (var db = new TransactionHandlerDemoEntities()) {
            var handler = db.TransactionHandler; // should be CommitFailureHandler
            
            db.AddToDemoTable(new DemoTable { Name = "TestEntiry1" });
            db.SaveChanges();
        }
    }
