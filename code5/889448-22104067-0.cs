    SqlDataReader sdr;
    var strSQL = "select * from Table01";
    var cmd = new SqlCommand { Connection = Cn, CommandText = strSQL };
    try
    {
    	sdr = cmd.ExecuteReader();
    	sdr.Read();
    	if (sdr.HasRows)
    	{
    		var field = sdr.GetValue(0);
    		// and so on....
    	}
    	dtrContID.Close();
    }
    catch (Exception err)
    {
    	// .......
    }
