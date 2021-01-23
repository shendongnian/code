    using (var connection = new SqlConnection(connectionString))
    using (var adapter = new SqlDataAdapter(query, connection))
    {
        adapter.SelectCommand.Parameters.AddWithValue(paramName, paramValue);
        // ...
    }
