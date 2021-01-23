    private KeyValuePair<string, int>[] GetData()
    {
	SqlConnection conn = new SqlConnection("connectionstring");
	SqlCommand comm = new SqlCommand("SELECT column1, column2 FROM mytable");
	conn.Open();
	try
	{
		SqlDataReader sr = comm.ExecuteReader();
		IList<KeyValuePair<string, int>> returnColl = new List<KeyValuePair<string, int>>();
		if (sr.HasRows)
		{
			while(sr.Read())
			{
				returnColl.Add(new KeyValuePair<string, int>() { Key = sr["column1"].ToString(), Value = sr["column2"] });
			}
		}
	}
	finally
	{
		conn.Close();
	}
	return returnColl.ToArray();
    }
