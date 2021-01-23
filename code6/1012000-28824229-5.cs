    SqlConnection connection = GetConnection();
    SqlTransaction transaction = null;
    try
    {
        connection.Open();
        transaction = connection.BeginTransaction();
        SqlCommand logCommand = new SqlCommand("select 'Log before main command'", connection, /* here */ transaction);
        logCommand.ExecuteNonQuery();
        string sql = "SELECT 1";
        SqlCommand command = new SqlCommand(sql, connection, transaction);
        int rows = command.ExecuteNonQuery();
        logCommand = new SqlCommand("select 'Log after main command'", connection, /* and here */ transaction);
        logCommand.ExecuteNonQuery();
        // Other similar code
        transaction.Commit();
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
