    // first read *.xls file into a DataTable; don't wory it is very quick.
    public DataTable ReadExcelFile(string strFilePath)
    {
    	string sConnectionString  = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + strFilePath + "; Extended Properties=\"Excel 8.0; HDR=No; IMEX=1;\"";
    	OleDbConnection objConn = new OleDbConnection(sConnectionString);
    	objConn.Open();
    	DataTable sdt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        // Change this part to read 1 row    
    	String str = "SELECT TOP(2) * FROM [" + sdt.Rows[0]["TABLE_NAME"].ToString() + "]";
    	//String str = "SELECT * FROM [" + sdt.Rows[0]["TABLE_NAME"].ToString() + "]";
    	OleDbCommand objCmdSelect = new OleDbCommand(str, objConn);
    	OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
    	objAdapter1.SelectCommand = objCmdSelect;
    	DataTable dt = new DataTable();
    	
    	objAdapter1.Fill(dt);
    	objConn.Close();
    	dt.AcceptChanges();
    	return dt;
    }
