    foreach(DataRow row in dt.Rows)
	{
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			Console.Write("{0} \t \n", row[i].ToString());
		}
	}
	
