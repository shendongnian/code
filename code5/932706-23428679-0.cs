    SqlConnection connection;
    try
    {
        connection = new SqlConnection(connectionString);
        ...
        connection.Close();
    }
    finally
    {
        connection.Dispose();
    }
