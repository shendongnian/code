    SqlConnection connection = GetConnection();
    SqlTransaction transaction = null;
    
    try
    {
        connection.Open();
        transaction = connection.BeginTransaction();
    
        SqlCommand logCommand = new SqlCommand("Log before main command", connection); // <--- did not give the transaction to the command
        logCommand.ExecuteNonQuery(); // <--- Exception: ExecuteNonQuery requires the command to have a transaction ...
    
        string sql = "SELECT 1";
        SqlCommand command = new SqlCommand(sql, connection, transaction);
        int rows = command.ExecuteNonQuery();
    
        logCommand = new SqlCommand("Log after main command", connection);
        logCommand.ExecuteNonQuery(); // <--- Same error also would have happened here
    
        // Other similar code
    
        transaction.Commit();
        command.Dispose();
    }
    catch { /* Rollback etc */ }
    finally { /* etc */ }
