    async Task Main()
    {
    	var startDate = new DateTime(2011, 1, 1);
    	var endDate = new DateTime(2012, 1, 1);
    
    	var account = CloudStorageAccount.Parse("connString");
    	var client = account.CreateCloudTableClient();
    	var table = client.GetTableReference("TableName");
    	
    	var dates = Enumerable.Range(0, Math.Abs((startDate.Month - endDate.Month) + 12 * (startDate.Year - endDate.Year)))
    		.Select(offset => startDate.AddMonths(offset))
    		.ToList();
    
    	foreach (var date in dates)
    	{
    		var key = $"{date.ToShortDateString()}";
    
    		var query = $"(PartitionKey eq '{key}')";
    		var rangeQuery = new TableQuery<TableEntity>().Where(query);
    
    		var result = table.ExecuteQuery<TableEntity>(rangeQuery);
    		$"Deleting data from {date.ToShortDateString()}, key {key}, has {result.Count()} records.".Dump();
    
    		var allTasks = result.Select(async r =>
    		{
    			try
    			{
    				await table.ExecuteAsync(TableOperation.Delete(r));
    			}
    			catch (Exception e) { $"{r.RowKey} - {e.ToString()}".Dump(); }
    		});
    		await Task.WhenAll(allTasks);
    	}
    }
