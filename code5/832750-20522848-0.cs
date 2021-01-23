    string connectionString = "Server=localhost;Database=dbName;Uid=Username;Pwd=Password";
    using (var sqlConnection = new SqlConnection(connectionString))
    {
        var query = @"UPDATE Ware
                        SET Price = @Price
                      WHERE WareNr > 0 AND WareNr <= 20000 AND Price >= 200";
        sqlConnection.Open();
        using (var command = new SqlCommand(query, sqlConnection))
        {
            command.Parameters.AddWithValue("@Price", 100 * 1.02);
            var dataReader = command.ExecuteNonQuery();
        }
        
        sqlConnection.Close();
    }
