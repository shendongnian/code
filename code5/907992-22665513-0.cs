	// create Table with ID, ValueX, ValueY
	var table1 = new DataTable();
	var id = table1.Columns.Add("ID");
	var x = table1.Columns.Add("ValueX");
	var y = table1.Columns.Add("ValueY");
	
	// set primary key constain so we can search for specific rows
	table1.PrimaryKey = new[] {id, x};
	
	// some sample data
	table1.Rows.Add(new Object[] {1, 1, 100});
	table1.Rows.Add(new Object[] {2, 2, 200});
	
	// find the row with key {1, 1} and update it, if it exists
	// else you would want to create a new row
	var exisiting = table1.Rows.Find(new Object[] {1, 1});
	if (exisiting != null)
		exisiting.ItemArray = new object[] {1, 1, 9999};
