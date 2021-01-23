    SqlConnection connection = new SqlConnection();
    SqlDataReader reader = null;
    try
    {
        connection.Open();  // you are missing this as a possible source of exceptions
        SqlCommand command = new SqlCommand("SELECT * FROM TableName", connection);
        reader = command.ExecuteReader();  // you are missing this as a possible source of exceptions
        // read and process data somehow (possible source of exceptions)
    }
    catch (SqlException ex)
    {
    }
    catch (Exception ex)
    {
        // handle exception somehow
    }
    finally
    {
        if (reader != null) reader.Close();
        connection.Close();
    }
