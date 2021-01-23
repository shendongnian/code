    connection.Open();
    using (var tran = connection.BeginTransaction(IsolationLevel.ReadCommitted))
    {
        using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, tran))
        {
