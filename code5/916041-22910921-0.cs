    using (SqlConnection sqlConnection = new SqlConnection(connection_string))
    {
        sqlConnection.Open();
        using (SqlCommand sqlCommand = new SqlCommand("SQL code here using number from foreach loop", sqlConnection))
        {
            foreach (int number in numberList)
            {
                //Modify command parameters if needed
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
