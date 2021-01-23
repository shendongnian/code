    SqlConnection connection = new SqlConnection();
    try
    {
        // Operations.
    }
    finally
    {
        if (connection != null)
        {
            connection.Dispose();
        }
    }
