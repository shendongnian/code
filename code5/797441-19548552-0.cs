    private void Form1_Load(object sender, EventArgs e)
    {
    	using (var con = new OleDbConnection())
    	{
    		con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\Database1.accdb;";
    		con.Open();
    		using (var cmd = new OleDbCommand())
    		{
    			cmd.Connection = con;
    			cmd.CommandText = "SELECT FirstName, website FROM Clients WHERE ID = 1";
    			OleDbDataReader rdr = cmd.ExecuteReader();
    			rdr.Read();
    			String fName = rdr["FirstName"].ToString();
    			String url = rdr["website"].ToString();
    			if (url.Substring(0,1).Equals("#"))
    			{
    				// remove leading and trailing hash marks from URL
    				//     as retrieved from a Hyperlink field in Access 
    				url = url.Substring(1, url.Length - 2);
    			}
    			linkLabel1.Text = String.Format("Link to {0}'s website", fName);
    			linkLabel1.Links.Add(0, linkLabel1.Text.Length, url);
    		}
    		con.Close();
    	}
    }
    
    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
    	string target = e.Link.LinkData as string;
    	System.Diagnostics.Process.Start(target);
    }
