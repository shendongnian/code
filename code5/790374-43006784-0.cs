    ds = new DataSet();
	ds.Tables.Add("Table1");
	ds.Tables[0].Load(reader);
	for (int ii = 1; ii < expectedTableCount; ii++)
	{
		ds.Tables.Add("Table" + (ii + 1));
		ds.Tables[ii].Load(reader);
	}
