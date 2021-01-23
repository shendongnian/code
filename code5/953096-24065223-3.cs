    string fileName = "C:\\Temp\\test.csv";
    string connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"TEXT;HDR=YES;FMT=Delimited\";", 	Path.GetDirectoryName(fileName));
    
    using (var connection = new System.Data.OleDb.OleDbConnection(connectionString)) 
    {
    	string sql = "Select Foo, `100#0` From " + Path.GetFileName(fileName);
    	using (var adapter = new System.Data.OleDb.OleDbDataAdapter(sql, connection)) 
    	{
    		var table = new DataTable();
    		var result = adapter.Fill(table);
    		table.Dump(); // LinqPad method to display result for verification
    	}
    }
