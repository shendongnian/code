    using (SqlConnection connection = new SqlConnection("connection string"))
    using (SqlTransaction transaction = connection.BeginTransaction())
    using (SqlCommand command = new SqlCommand("command text", connection) { Transaction = transaction })
    {
        connection.Open();
        try
        {
            command.ExecuteNonQuery();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
