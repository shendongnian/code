    // query all rows
    CloudTable peopleTable = tableClient.GetTableReference("myTableName");
    var query = new TableQuery<MyTableEntity>();
    var result = await remindersTable.ExecuteQuerySegmentedAsync(query, null);
    
    // Create the batch operation.
    TableBatchOperation batchDeleteOperation = new TableBatchOperation();
    foreach (var row in result)
    {
        batchDeleteOperation.Delete(row);
    }
    
    // Execute the batch operation.
    await remindersTable.ExecuteBatchAsync(batchDeleteOperation);
