	var dt = new DataTable();
	dt.Columns.Add(new DataColumn());
	dt.Columns.Add(new DataColumn());
	var row1 = dt.NewRow();
	row1[0] = "0";
	row1[1] = "1";
	dt.Rows.Add(row1);
	foreach (DataRow row in dt.Rows)
	{
		foreach (DataColumn col in dt.Columns)
		{
			var strMsg = col.ColumnName + ": " + row[dt.Columns.IndexOf(col)].ToString();
			Console.WriteLine(strMsg);
		}
	}
