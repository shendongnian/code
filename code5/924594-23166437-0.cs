    SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString);
      public Boolean InserData(string abID, string fHitType,string DateOfHit, string TimeOfHit,string fEmpid)
    {
        // SqlConnection oConnection = new SqlConnection("Connection_String");
        SqlCommand oCommand = new SqlCommand();
        oCommand.Connection = oConnection;
        oCommand.CommandText = "SP_insertData";
        oCommand.CommandType = CommandType.StoredProcedure;
        oCommand.Parameters.AddWithValue("@abID", abID);
        oCommand.Parameters.AddWithValue("@fHitType", fHitType);
        oCommand.Parameters.AddWithValue("@DateOfHit", DateOfHit);
        oCommand.Parameters.AddWithValue("@TimeOfHit", TimeOfHit);
        oCommand.Parameters.AddWithValue("@fEmpid", fEmpid);
        oConnection.Open();
        Boolean Result = Convert.ToBoolean(oCommand.ExecuteNonQuery());
        oConnection.Close();
        return Result;
    }
