    public class MigrationDataStoreFactory : IDbContextFactory<DataStore>
    {
        public DataStore Create()
        {
            return new DataStore(0); 
        }
    }
