    var acc = new CloudStorageAccount(
                             new StorageCredentials("account name", "account key"), false);
    var tableClient = acc.CreateCloudTableClient();
    var table = tableClient.GetTableReference("table name");
    var entities = table.ExecuteQuery(new TableQuery<MyEntity>()).ToList();
