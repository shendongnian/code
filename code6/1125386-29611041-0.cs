    int count = 0;
    do
    {
        TableQuerySegment<DynamicTableEntity> querySegment =
            await currentTable.ExecuteQuerySegmentedAsync(query, token);
        token = querySegment.ContinuationToken;
        foreach (DynamicTableEntity entity in querySegment)
        {
            ++count;
        }
    }
    while (token != null);
