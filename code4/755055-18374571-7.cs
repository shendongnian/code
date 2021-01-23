    public int CreateNewMember(string Mem_NA, string Mem_Occ )
    {
	    // values 0 --> -99 are SQL reserved.
		int new_MEM_BASIC_ID = -1971;	
		SqlConnection SQLconn = new SqlConnection(Config.ConnectionString);
		SqlCommand cmd = new SqlCommand("INS_MEM_BASIC", SQLconn);
		cmd.CommandType = CommandType.StoredProcedure;
		SqlParameter outPutVal = new SqlParameter("@New_MEM_BASIC_ID", SqlDbType.Int);
		outPutVal.Direction = ParameterDirection.Output;
		cmd.Parameters.Add(outPutVal);
		cmd.Parameters.Add("@na", SqlDbType.Int).Value = Mem_NA;
		cmd.Parameters.Add("@occ", SqlDbType.Int).Value = Mem_Occ;
		SQLconn.Open();
		cmd.ExecuteNonQuery();
		SQLconn.Close();
		if (outPutVal.Value != DBNull.Value) new_MEM_BASIC_ID = Convert.ToInt32(outPutVal.Value);
		    return new_MEM_BASIC_ID;
    }
