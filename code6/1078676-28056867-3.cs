    DataSet output = new DataSet();
    using (OleDbConnection conn = new OleDbConnection(strConn))
    {
    	conn.Open();
    	DataTable schemaTable = conn.GetOleDbSchemaTable(
    		OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        // e.g. Rows in SchemaTable are Sheets in Xlsx file.
    	foreach (DataRow schemaRow in schemaTable.Rows)
    	{
        	//... 
        	string sheet = schemaRow["TABLE_NAME"].ToString();
    		var select = "SELECT * FROM [" + sheet + "]";
    		OleDbCommand cmd = new OleDbCommand(select, conn);
    		cmd.CommandType = CommandType.Text;
    		DataTable outputTable = new DataTable(sheet);
    		output.Tables.Add(outputTable);
    		new OleDbDataAdapter(cmd).Fill(outputTable);
    	}
    }
