    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                TableServiceContext serviceContext = tableClient.GetDataServiceContext();
    
                var partitionQuery =
                    (from e in serviceContext.CreateQuery<MyData1>(_tableName)
                     where e.PartitionKey.CompareTo("15") >= 0 && e.PartitionKey.CompareTo("39") <= 0
                     select new MyData1()
                     {
                         PartitionKey = e.PartitionKey,
                         RowKey = e.RowKey,
                         Timestamp = e.Timestamp,
                         Message = e.Message,
                         Level = e.Level,
                         Severity = e.Severity
                     }
                     ).AsTableServiceQuery();
    
                return partitionQuery.ToList<MyData1>();
