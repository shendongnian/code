    var rowCompare = String.Format("{0}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
    var items = new []{"1", "6", "10"};
            
    var filters =
        items.Select(key => TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, key)).ToArray();
    
    var combine =
        filters.Length > 0
            ? filters[0]
            : null;
    
    for (var k = 0; k < filters.Length; k++)
        combine = TableQuery.CombineFilters(combine, TableOperators.Or, filters[k]);
    
    var final = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.GreaterThan, rowCompare);
    if (!string.IsNullOrEmpty(combine))
        final = TableQuery.CombineFilters(final, TableOperators.And, combine);
    
    var query = new TableQuery<EntityReport>().Where(final);
    
    var client = CloudStorageAccount.DevelopmentStorageAccount.CreateCloudTableClient();
    var table = client.GetTableReference("EntityReports");
    var result = table.ExecuteQuery(query);
