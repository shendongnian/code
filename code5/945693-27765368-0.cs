    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + workingPath + ";Extended Properties=\"text;HDR=YES;FMT=Delimited(|)\"";
    
        using (OleDbConnection conn = new OleDbConnection(connString))
        {
        	using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + workingFilename, conn))
        	{
        		conn.Open();
        		OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
        		originalTable = new DataTable("");
        		dAdapter.Fill(originalTable);
        	}
        }
