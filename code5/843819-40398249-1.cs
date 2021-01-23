    public class LogRepository : ILogRepository
    {
        protected CloudTable table;
        //ctor that initialize the azure table
        public LogRepository(string tableName, string connectionString)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(connectionString))
                throw new ArgumentException()
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            table = tableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
        }
        //read from table and Cast the rows to LogModel
        public IEnumerable<LogModel> GetLogs()
        {
            var query = new TableQuery<LogEntityWrapper>();
            var entities = table.ExecuteQuery(query);
            //The Cast doesn't break laziness
            return entities.Cast<LogModel>();
        }
        // A minimal wrapper, just the implementations of Read and Write Entity
        private class LogEntityWrapper : LogModel, ITableEntity
        {
            public void ReadEntity(IDictionary<string, EntityProperty> properties, OperationContext operationContext)
            {
                TableEntity.ReadUserObject(this, properties, operationContext);
            }
            public IDictionary<string, EntityProperty> WriteEntity(OperationContext operationContext)
            {
                return TableEntity.WriteUserObject(this, operationContext);
            }
        }
    }
