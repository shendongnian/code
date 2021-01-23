    try
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = new SqlCommand(connection);
        command.CommandText = sqlQuery;
        command.Parameters.Add("id", id);
        command.ExecuteNonQuery();
        connection.Close();
    }
    catch(Exception e)
    {
        // do something with the exception
    }
