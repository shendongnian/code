    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    CloudTable eventLogsTable = tableClient.GetTableReference("WADPerformanceCountersTable");
    TableQuery query = new TableQuery();
    Console.WriteLine("List perf counter results in pages:");
    TableContinuationToken token = null;
    do
    {
        var segment = eventLogsTable.ExecuteQuerySegmented(query, token, null, null);
        foreach (var wadCounter in segment)
        {
            Console.WriteLine(wadCounter.PartitionKey);
            Console.WriteLine(wadCounter.RowKey);
            Console.WriteLine(wadCounter.Timestamp);
        }
        token = segment.ContinuationToken;
    }
    while (token != null);
