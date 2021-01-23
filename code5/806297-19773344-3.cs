    try
    {
    SqlConnection connection = new SqlConnection(strConnectionString);
    connection.Open();
    }
    finally
    {
    connection.Close();
    }
