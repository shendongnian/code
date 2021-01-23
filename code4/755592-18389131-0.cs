    using (IDbConnection connection = ...)
    {
        connection.Open();
        using (IDbTransaction transaction = connection.BeginTransaction())
        {
            using (IDbCommand command = ...)
            {
                command.Connection = connection;
                command.Transaction = transaction;
                ...
            }
            ...
            transaction.Commit();
        }
    }
