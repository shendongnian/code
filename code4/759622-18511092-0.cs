	DataSet dataset = new DataSet();
	using (var adapter = new SqlDataAdapter("yourSP", yourConnectionString))
	{
		adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
		adapter.Fill(dataset);
	}
	for (int i = 0; i < dataset.Tables.Count; i++)
	{
		// Do something for each recordset
	}
