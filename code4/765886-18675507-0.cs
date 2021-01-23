    using (OleDbConnection conn = new OleDbConnection(connStr)) 
    {
    	conn.Open();
    	OleDbDataAdapter adapter = new OleDbDataAdapter("select * from confirm", conn);
    	OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
    	DataTable table = new DataTable();
    	adapter.Fill(table);
    	DataRow row = table.NewRow();
    	row("k") = "november";
    	row("v") = "eleven";
    
    	//**You missed this**
    	table.Rows.Add(row);
    
    	adapter.UpdateCommand = builder.GetUpdateCommand();
    	adapter.Update(table);
    	// table.AcceptChanges();
    	return table;
    }
