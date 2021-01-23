    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        string queryString = "UPDATE Ware SET Price = Price * 1.02 WHERE WareNr > 0 AND WareNr <= 20000 AND Price >= 200";
        SqlCommand command = new SqlCommand(queryString, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }
