    SqlConnection sqlConnection = new SqlConnection();
    SqlCommand sqlCommand = new SqlCommand();
    sqlConnection.ConnectionString = "Data Source=SERVERNAME;Initial Catalog=DATABASENAME;Integrated Security=True";
    public void samplefunct(params object[] adparam)
       {
           sqlConnection.Open();
           sqlCommand.Connection = sqlConnection;
           sqlCommand.CommandType = CommandType.StoredProcedure;
           sqlCommand.CommandText = "SPName";
           sqlCommand.Parameters.Add("@param1", SqlDbType.VarChar).Value = adparam[0];
           sqlCommand.Parameters.Add("@param2", SqlDbType.VarChar).Value = adparam[1];
           sqlCommand.Parameters.Add("@Param3", SqlDbType.VarChar).Value = adparam[2];
           sqlCommand.ExecuteNonQuery();
    }
