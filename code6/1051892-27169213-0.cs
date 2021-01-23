    using(var con = new SqlConnection(conStr))
	{
		var cmd = new SqlCommand("MY_SP",con);
		cmd.CommandType = CommandType.StoredProcedure;
		var da = new SqlDataAdapter(cmd);
		var ds = new DataSet();
		da.Fill(ds);
	
		if(ds.Tables.Count > 0)
		{
			foreach(var dr in ds.Tables[0].Rows)
			{
				// Do stuffs with dr
			}
	 	}
	}
