    namespace Microsoft.WindowsAzure.Storage.Table
    {
        public static class CloudTableExtensions
        {
            public static TEntity GetTableEntity<TEntity>(this CloudTable cloudTable, BrokeredMessage brokeredMessage, string partitionKeyPropertyName, string rowKeyPropertyName, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
                where TEntity : ITableEntity, new()
            {
                var partitionKey = brokeredMessage.Properties[partitionKeyPropertyName] as string;
                var rowKey = brokeredMessage.Properties[rowKeyPropertyName] as string;
                return GetTableEntity<TEntity>(cloudTable, partitionKey, rowKey, requestOptions, operationContext);
            }
            public static TEntity GetTableEntity<TEntity>(this CloudTable cloudTable, string partitionKey, string rowKey, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
                where TEntity : ITableEntity, new()
            {
                var singleInstanceQuery = (Expression<Func<TEntity, bool>>)(x => x.PartitionKey == partitionKey && x.RowKey == rowKey);
                IEnumerable<TEntity> queryResults = cloudTable.ExecuteQuery(singleInstanceQuery, requestOptions, operationContext);
                return queryResults.SingleOrDefault();
            }
            public static IEnumerable<TEntity> ExecuteQuery<TEntity>(this CloudTable cloudTable, Expression<Func<TEntity, bool>> expression, TableRequestOptions requestOptions = null, OperationContext operationContext = null)
                where TEntity : ITableEntity, new()
            {
                var query = cloudTable.CreateQuery<TEntity>().Where(expression) as TableQuery<TEntity>;
                return cloudTable.ExecuteQuery(query, requestOptions, operationContext);
            }
        }
    }
