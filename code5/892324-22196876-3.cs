    protected void btnImport_Click(object sender, EventArgs e) {
    	string connString = "";
    	string strFileType = Path.GetExtension(fileuploadWord.FileName).ToLower();
    	string path = fileuploadWord.PostedFile.FileName;
    	
    	//Connection String to Word file
    	if (strFileType.Trim() == ".doc") {
    		connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Word 8.0;HDR=Yes;IMEX=2\"";
    	}
    	else if (strFileType.Trim() == ".docx") {
    		connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Word 12.0;HDR=Yes;IMEX=2\"";
    	}
    	
    	string query = "SELECT * FROM [document1$]";
    	OleDbConnection conn = new OleDbConnection(connString);
    	if (conn.State == ConnectionState.Closed)
    		conn.Open();
    		
    	OleDbCommand cmd = new OleDbCommand(query, conn);
    	OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    	DataSet ds = new DataSet();
    	da.Fill(ds);
    	grvWordData.DataSource = ds.Tables[0];
    	grvWordData.DataBind();
    	da.Dispose();
    	conn.Close();
    	conn.Dispose();
    }
