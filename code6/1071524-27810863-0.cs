    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        var transaction = connection.BeginTransaction();
        try
        { 
             // Initialize and execute the first command
             SqlCommand command = GetFirstCommand();
             command.Connection = connection;
             command.ExecuteNonQuery();
             // Initialize and execute the first command
             command = GetSecondCommand();
             command.Connection = connection;
             command.ExecuteNonQuery();
             transaction.Commit();
        }
        catch (Exception ex)
        {
             transaction.Rollback();
        }
    }
