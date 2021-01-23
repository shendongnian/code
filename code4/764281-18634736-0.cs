    string queryString = "SELECT integer_value FROM table_name";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            label1.Text = reader.getSqlInt32(0).ToString();
        }
        reader.close();
    }
