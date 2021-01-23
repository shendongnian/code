	//Make a new DataTable
	DataTable newTable = new DataTable();
	//Create Columns based on DataGridView headers
	foreach (DataGridViewColumn col in dataGridView1.Columns)
	{
		newTable.Columns.Add(col.HeaderText);
	}
	//Add each row of data from DataGridView into new DataTable in the displayed order
	foreach (DataGridViewRow row in dataGridView1.Rows)
	{
		DataRow newRow = newTable.NewRow();
		foreach(DataGridViewCell cell in row.Cells)
		{
			newRow[cell.ColumnIndex] = cell.Value;
		}
		newTable.Rows.Add(newRow);
	}
	//Set your original DataTable to the new DataTable with the correct ordering
	table = newTable;
