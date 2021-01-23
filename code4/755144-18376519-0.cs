    private IEnumerable<T> FetchAllEntities()
    {
        List<T> allEntities = new List<T>();
        CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;
        CloudTable table = storageAccount.CreateCloudTableClient().GetTableReference("MyTable");
        Microsoft.WindowsAzure.Storage.Table.TableContinuationToken tableContinuationToken = null;
        do
        {
            var queryResponse = table.ExecuteQuerySegmented<T>(null, tableContinuationToken, null, null);
            tableContinuationToken = queryResponse.ContinuationToken;
            allEntities.AddRange(queryResponse.Results);
        }
        while (tableContinuationToken != null);
        return allEntities;
    }
