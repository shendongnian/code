    string sql = "SELECT email FROM Table WHERE Field = @Parameter";
    string variable;
    using (var connection = new SqlConnection("Your Connection String"))
    using (var command = new SqlCommand(sql, connection))
    {
        command.Parameters.AddWithValue("@Parameter", someValue);
        connection.Open();
        variable = (string)command.ExecuteScalar();
    }
