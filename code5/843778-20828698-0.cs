    using(SqlConnection connection = new SqlConnection("connection string"))
    {
        using(SqlCommand command = new SqlCommand("command",connection);
        {
            //Add params as in your example
            connection.Open();
            command.ExecuteNonQuery(); // Or Execute reader to get results back
            connection.close(); //The using statement will close dispose, which will close the connection so this isn't strictly required.
        }
    }
