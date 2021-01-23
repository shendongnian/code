    using (var connection = GetConnection())
    using (var command = new SqlCommand(sql, connection))
    {
        connection.InfoMessage += (s, e) =>
        {
            Debug.WriteLine(e.Message);
        };
        connection.Open();
        numberOfRecords = command.ExecuteNonQuery();
    }
