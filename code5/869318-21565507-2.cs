    using (var connection = new SqlConnection(strConnectionString))
    {
        using (var command = new SqlCommand(builder.ToString().TrimEnd(','), connection))
        {
            command.Parameters.AddRange(parameters.ToArray());
            connection.Open();
    
            int recordsAffected = command.ExecuteNonQuery();
        }
    }
