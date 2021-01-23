    string connectionString = "YourConnectionString";
    using (SqlConnection connection = new SqlConnection(connectionString)
    {
        connection.Open();
        string query = "SELECT Name FROM YourTable";
        SqlCommand command = new SqlCommand(query, connection);
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read()
        }
   
    }
