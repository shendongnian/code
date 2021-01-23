    Queue queue = new Queue();
                queue.Enqueue("PartitionKeyTodelete1");
                queue.Enqueue("PartitionKeyTodelete2");
                queue.Enqueue("PartitionKeyTodelete3");
    
                while (queue.Count > 0)
                {
                    string partitionToDelete = (string)queue.Dequeue();
    
                    TableQuery<TableEntity> deleteQuery = new TableQuery<TableEntity>()
                      .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionToDelete))
                      .Select(new string[] { "PartitionKey", "RowKey" });
    
                    TableContinuationToken continuationToken = null;
    
                    do
                    {
                        var tableQueryResult = await myTable.ExecuteQuerySegmentedAsync(deleteQuery, continuationToken);
    
                        continuationToken = tableQueryResult.ContinuationToken;
    
                        // Split into chunks of 100 for batching
                        List<List<TableEntity>> rowsChunked = tableQueryResult.Select((x, index) => new { Index = index, Value = x })
                            .Where(x => x.Value != null)
                            .GroupBy(x => x.Index / 100)
                            .Select(x => x.Select(v => v.Value).ToList())
                            .ToList();
    
                        // Delete each chunk of 100 in a batch
                        foreach (List<TableEntity> rows in rowsChunked)
                        {
                            TableBatchOperation tableBatchOperation = new TableBatchOperation();
                            rows.ForEach(x => tableBatchOperation.Add(TableOperation.Delete(x)));
    
                            await myTable.ExecuteBatchAsync(tableBatchOperation);
                        }
                    }
                    while (continuationToken != null);
                }
