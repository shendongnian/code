    using(var sqlConnection = new SqlConnection(CNN_STRING))
    using (var command = new SqlCommand(sb.ToString(), sqlConnection))
    {
        sqlConnection.Open();
        command.ExecuteNonQuery();
    }
