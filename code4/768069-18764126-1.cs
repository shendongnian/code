    public class DataStoreFactory : Disposable, IDataStoreFactory
    {
        private DataStore _database;
        private int _userId;
        private string _connectionString;
        // This is the constructor that will be called by the 
        // MigrationDataStoreFactory class
        public DataStoreFactory(int userId)
        {
            _userId = userId;
        }
        public DataStoreFactory(int userId, string connectionString)
        {
            _userId = userId;
            _connectionString = connectionString;
        }
        public IDataStore Get()
        {
            // If we have a connection string, construct our context with it,
            // if not, use the new constructor
            if(_connectionString != null)
                _database = new DataStore(_userId, _dateTimeServices, _connectionString);
            else
                _database = new DataStore(_userId, _dateTimeServices);
            return _database;
        }
        protected override void DisposeCore()
        {
            if (_database != null) _database.Dispose();
        }
    }
