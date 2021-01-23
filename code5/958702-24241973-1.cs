    public void FetchData(Action<SqlDataReader> bindMethod)
    {
        using (SqlConnection sqlConnection = new SqlConnection("ConnectionString"))
        {
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("Query", sqlConnection))
            {
                bindMethod.Invoke(sqlCommand.ExecuteReader(CommandBehavior.CloseConnection));
            }
        }
    }
