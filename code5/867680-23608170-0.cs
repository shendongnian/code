    public static Task<TableQuerySegment<T>> ExecuteQueryAsync<T>(
            this CloudTable table,
            TableQuery<T> query,
            TableContinuationToken token,
            CancellationToken ct = default(CancellationToken))
            where T : ITableEntity, new()
        {
            ICancellableAsyncResult ar = table.BeginExecuteQuerySegmented(query, token, null, null);
            ct.Register(ar.Cancel);
            return Task.Factory.FromAsync<TableQuerySegment<T>>(ar, table.EndExecuteQuerySegmented<T>);
        }
