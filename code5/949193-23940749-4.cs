    var acc = new CloudStorageAccount(
                             new StorageCredentials("account name", "account key"), false);
    var tableClient = acc.CreateCloudTableClient();
    var table = tableClient.GetTableReference("table name");
    TableContinuationToken token = null;
    var entities = new List<MyEntity>();
    do
    {
        var queryResult = table.ExecuteQuerySegmented(new TableQuery<MyEntity>(), token);
        entities.AddRange(queryResult.Results);
        token = queryResult.ContinuationToken;
    } while (token != null);
