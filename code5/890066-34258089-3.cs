    var query = (from s in table.CreateQuery<SampleEntity>()
                where s.PartitionKey == sampleUID.ToString() select s)
                .AsTableQuery<SampleEntity>();
    TableContinuationToken continuationToken = null;
    do
    {
        // Execute the query async until there is no more result
        var queryResult = await query.ExecuteSegmentedAsync(continuationToken);
        foreach (var entity in queryResult)
        {
        }
        continuationToken = queryResult.ContinuationToken;
    } while (continuationToken != null);
