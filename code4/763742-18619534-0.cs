    using (OleDbConnection connection = new OleDbConnection(connectionString))
    using (OleDbCommand command = new OleDbCommand(sqlx , connection))
    {
        try
        {
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            updRes = "Failed! :("+Environment.NewLine+"ERROR: " + ex.Message + Environment.NewLine;
        }
    }
