    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
    {
        using (var conn = GetConnection())
        {
            string query = 
            @"some query that may contain transaction itself 
            or some SP whith transaction included"
            using (var command = new SqlCommand(query, conn))
            command.ExecuteNonQuery();
        }
        scope.Complete();
    }
