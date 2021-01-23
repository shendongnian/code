    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
        // Need to define cmdText.
        string cmdText = "";
        using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection))
        {
            sqlCommand.CommandType = CommandType.Text;
            int result = sqlCommand.ExecuteNonQuery();
        }
    }
