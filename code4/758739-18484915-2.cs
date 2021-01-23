    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
        // Need to define cmdText.
        string cmdText = "";
        using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
        {
            sqlCommand.CommandType = CommandType.Text;
            sqlConnection.Open();
            var result = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
