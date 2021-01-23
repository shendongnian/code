    [open file dialog code..]
    try
    {
    	string path = this.openFileDialog1.FileName;
    	if (Path.GetExtension(path) == ".xls")
    	{
    		oledbConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
    	}
    	else if (Path.GetExtension(path) == ".xlsx")
    	{
    		oledbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
    	}
    	oledbConn.Open();
    
    	DataSet ds = new DataSet();
    	
    	OleDbCommand cmd = new OleDbCommand();
    	cmd.Connection = oledbConn;
    	cmd.CommandType = CommandType.Text;
    	cmd.CommandText = "SELECT * FROM [sheet1$]";
    	
    	OleDbDataAdapter oleda = new OleDbDataAdapter();
    	oleda = new OleDbDataAdapter(cmd);
    	oleda.Fill(ds);
    	ds.Tables[0].TableName = "DataTable1";
    
    	this.DataTable1BindingSource.DataSource = ds;
    	this.reportViewer1.RefreshReport();
    }
    catch (Exception ex)
    {
    }
    finally
    {
    	oledbConn.Close();
    }
