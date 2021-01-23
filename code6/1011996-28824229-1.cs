    try
    {
        connection.Open();
        // No transaction
        SqlCommand logCommand = new SqlCommand("select 'Log before main command'", connection);
        logCommand.ExecuteNonQuery();
        // Now create the transaction
        transaction = connection.BeginTransaction();
        string sql = "SELECT 1";
        SqlCommand command = new SqlCommand(sql, connection, transaction);
        int rows = command.ExecuteNonQuery();
        transaction.Commit();
        // Transaction is completed, now there is no transaction again
        logCommand = new SqlCommand("select 'Log after main command'", connection);
        logCommand.ExecuteNonQuery();
        // Other similar code
        command.Dispose();
    }
    //catch { /* Rollback etc */ }
    finally
    {
        if (transaction != null)
        {
            transaction.Dispose();
        }
    }
