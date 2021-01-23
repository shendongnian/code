    using (SqlConnection sqlConnection = new SqlConnection(connection_string))
    {
        sqlConnection.Open();
        foreach(int number in numberList)
        {
            using (SqlCommand sqlCommand = new SqlCommand("SQL code here using number from foreach loop", sqlConnection))
            {
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
