    public static async Task<IList<T>> ExecuteQueryAsync<T>(this CloudTable table, TableQuery<T> query, CancellationToken ct = default(CancellationToken), Action<IList<T>> onProgress = null) where T : ITableEntity, new()
    {
		var runningQuery = new TableQuery<T>()
		{
			FilterString = query.FilterString,
			SelectColumns = query.SelectColumns
		};
		var items = new List<T>();
        TableContinuationToken token = null;
		do
		{
			runningQuery.TakeCount = query.TakeCount - items.Count;
			TableQuerySegment<T> seg = await table.ExecuteQuerySegmentedAsync<T>(runningQuery, token);
			token = seg.ContinuationToken;
			items.AddRange(seg);
			if (onProgress != null) onProgress(items);
			
		} while (token != null && !ct.IsCancellationRequested && (query.TakeCount == null || items.Count < query.TakeCount.Value));
        return items;
	}
