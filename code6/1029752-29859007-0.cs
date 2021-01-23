    /// <summary>
    /// Returns table entities
    /// </summary>
    public List<dynamic> GetEntities(string tableName, int takeCount, string filters)
        {
            var table = TableClient.GetTableReference(tableName);
            var tableQuery = !filters.IsEmpty()
                                 ? new TableQuery<DynamicTableEntity>().Where(filters).Take(takeCount)
                                 : new TableQuery<DynamicTableEntity>().Take(takeCount);
            var tableResult = table.ExecuteQuery(tableQuery);
            List<dynamic> dynamicCollection = tableResult.ToDynamicList();
            return dynamicCollection;
        }
