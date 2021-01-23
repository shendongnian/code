    public static async Task<IList<TResult>> ExecuteQueryAsync<T, TResult>(this CloudTable table, TableQuery query, EntityResolver<TResult> resolver, Action<IList<TResult>> onProgress = null, CancellationToken cancelToken = default(CancellationToken))
                where T : ITableEntity, new()
    {
        var items = new List<TResult>();
        TableContinuationToken token = null;
    
        do
        {
            TableQuerySegment<TResult> seg = await table.ExecuteQuerySegmentedAsync(query: query, resolver: resolver, token: new TableContinuationToken(), cancellationToken: cancelToken).ConfigureAwait(false);
            token = seg.ContinuationToken;
            items.AddRange(seg);
            onProgress?.Invoke(items);
         }
         while (token != null && !cancelToken.IsCancellationRequested);
             return items;
         }
    }
