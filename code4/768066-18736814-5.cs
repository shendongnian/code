    public class MigrationDataStoreFactory : IDbContextFactory<DataStore>
    {
        public string _connectionString { get; set; }
        public MigrationDataStoreFactory(UnityContainer unityContainer)
        {
            _connectionString = unityContainer.Resolve<IDBConnectionSettings>().ConnectionString;
        }
        public DataStore Create()
        {
            return new DataStore(0, new DateTimeProvider(() => DateTime.Now), _connectionString);
        }
    }
