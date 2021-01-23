    int row;
	foreach (DataTable t in ds.Tables)
	{
		t.Columns.Add("RowNum",typeof(Int32));
		row = 1;
		foreach (DataRow r in t.Rows)
		{
			r["RowNum"] = r.IndexOf(r);
		}
	}
