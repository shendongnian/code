    // first read *.xls file into a DataTable; don't wory it is very quick.
    public DataTable ReadExcelFile(string strFilePath)
    {
    	string sConnectionString  = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + strFilePath + "; Extended Properties=\"Excel 8.0; HDR=No; IMEX=1;\"";
    	OleDbConnection objConn = new OleDbConnection(sConnectionString);
    	objConn.Open();
    	DataTable sdt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    	String str = "SELECT * FROM [" + sdt.Rows[0]["TABLE_NAME"].ToString() + "]";
    	OleDbCommand objCmdSelect = new OleDbCommand(str, objConn);
    	OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
    	objAdapter1.SelectCommand = objCmdSelect;
    	DataTable dt = new DataTable();
    	
    	objAdapter1.Fill(dt);
    	objConn.Close();
    	dt.AcceptChanges();
    	return dt;
    }
    // now working with DataTable
    System.Windows.Forms.ComboBox cmb = new System.Windows.Forms.ComboBox();
    for (int i = 0; i < dt.Columns.Count; i++)
    	cmb.Items.Insert(i, dt.Columns[i].ColumnName);
