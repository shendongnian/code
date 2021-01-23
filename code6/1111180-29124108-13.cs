	DataTable dt22 = new DataTable();
	dt22.Columns.Add("Tasks");
	dt22.Columns.Add("AnotherColumn");
	DataRow dr = dt22.NewRow();
	dr[0] = "task1";
	dr[1] = "c1";
	dt22.Rows.Add(dr);
	DataRow dr2 = dt22.NewRow();
	dr2[0] = "test2";
	dr2[1] = "c2";
	dt22.Rows.Add(dr2);
	StringBuilder sb = new StringBuilder();
	IEnumerable<string> columnNames = dt22.Columns.Cast<DataColumn>().
									  Select(column => column.ColumnName);
	sb.AppendLine(string.Join(",", columnNames));
	foreach (DataRow row in dt22.Rows)
	{
		IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
		sb.AppendLine(string.Join(",", fields));
	}
	File.WriteAllText(@"c:\Tasks.csv", sb.ToString());
