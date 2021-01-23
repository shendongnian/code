    public string GetData (string destinationFile)
    {
       string conectionString = "uid=One_User;pwd=One_Password;database=One_Database;server=One_Server";
       SqlConnection con = new SqlConnection(connectionString);
       SqlCommand sqlCmd = new SqlCommand(procedureName, con); 
       sqlCmd.CommandType = CommandType.StoredProcedure;  
       string returnValue = string.Empty;
       string procedureName = "spGet_Data";
       sqlCmd.Parameters.AddWithValue("@FileName", destinationFile);
       con.Open();
       var returnParameter = sqlCmd.Parameters.Add("@ret", SqlDbType.VarChar);
       returnParameter.Direction = ParameterDirection.ReturnValue;
       sqlCmd.ExecuteNonQuery();
       returnValue = returnParameter.Value.ToString();
       con.Close();
       return returnValue;
    }
