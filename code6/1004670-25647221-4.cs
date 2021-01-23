    [ContractClassFor(typeof(IWithSqlDbBackend))]
    public abstract class IWithSqlDbBackendContract : IWithSqlDbBackend
    {
        public string ConnectionString
        {
            get 
            {  
                Contract.Requires(!string.IsNullOrEmpty(ConnectionStringId), "Connection string id cannot be null or empty");
                Contract.Requires(ConfigurationManager.ConnectionStrings[ConnectionStringId] != null, "Connection string must be configured");
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()), "A connection string cannot be null");
                return null;
            }
        }
        public string ConnectionStringId
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()), "A connection string identifier cannot be null or empty");
                return null;
            }
        }
    }
