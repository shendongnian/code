    // Reads.
    using (var connection = new SqlConnection("data source=.; initial catalog=master; Integrated Security=True;"))
    {
        connection.Open();
    
        var command = new SqlCommand("select * from anything", connection);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var publishedDate = (DateTime)reader["published"];
        }
    }
