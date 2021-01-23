    SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString);
    public int InserData(string abID, string fHitType, string DateOfHit, string TimeOfHit, string fEmpid)
    {            
        SqlCommand oCommand = new SqlCommand("SP_insertData", oConnection);           
        oCommand.CommandType = CommandType.StoredProcedure;
        oCommand.Parameters.AddWithValue("@abID", abID);
        oCommand.Parameters.AddWithValue("@fHitType", fHitType);
        oCommand.Parameters.AddWithValue("@DateOfHit", DateOfHit);
        oCommand.Parameters.AddWithValue("@TimeOfHit", TimeOfHit);
        oCommand.Parameters.AddWithValue("@fEmpid", fEmpid);
        oConnection.Open();
        int Result = oCommand.ExecuteNonQuery();
        oConnection.Close();
        return Result;
    }
