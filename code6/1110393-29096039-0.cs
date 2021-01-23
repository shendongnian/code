    DataTable dataTable1 = new DataTable();
	dataTable1.Columns.Add("col1");
	dataTable1.Columns.Add("col2");
	dataTable1.Columns.Add("col3");
	foreach (var row in EmpDetails.Table)
	{
		dataTable1.Rows.Add(row.ToArray());
	}
	DataTable dataTable2 = new DataTable();
	dataTable2.Columns.Add("col1");
	dataTable2.Columns.Add("col2");
	dataTable2.Columns.Add("col3");
	foreach (var row in EmpDetails.Table1)
	{
		dataTable2.Rows.Add(row.ToArray());
	}
