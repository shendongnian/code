    SqlConnection conn;
    try
    {
        conn = new SqlConnection(connString);
    }
    finally
    {
        if (conn != null)
            conn.Dispose();
    }
