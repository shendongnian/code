    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand(query, connection))
    using (var adapter = new SqlDataAdapter(command))
    {
        command.Parameters.AddWithValue(paramName, paramValue);
        // ...
    }
