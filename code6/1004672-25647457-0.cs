    public class DbBackedPersonManager : IPersonManager
    {
        private readonly string _connectionString;
        public DbBackPersonManager()
        {
            Contract.Requires(ConfigurationManager.ConnectionStrings["SomeConnectionStringId"] != null, "A connection string is required in your application/web configuration file");
            _connectionString = ConfigurationManager.ConnectionStrings["SomeConnectionStringId"];
        }
 
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(_connectionString != null);
        }
        // Interface implementation snipped...
    }
