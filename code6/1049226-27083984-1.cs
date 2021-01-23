    var table = new DataTable();
    table.Columns.Add("Name", typeof(string));
    
    table.Rows.Add("foo");
    table.Rows.Add("bar");
    
    table.AcceptChanges();
    
    foreach(DataRow row in table.Rows)
    {
    	if ((string)row["Name"] == "foo")
    	{
    		row.Delete();
    	}
    }
    
    Console.WriteLine(table.Rows[0].RowState);	// Deleted
    Console.WriteLine(table.Rows.Count);		// 2
    table.Rows[0].AcceptChanges();
    Console.WriteLine(table.Rows.Count);		// 1
