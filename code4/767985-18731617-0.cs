    public DataTable dattab;
    public void GetData()
    {
    	//setup the parameters for connecting
        string connString = @"";// You need to define you connection string here.
        string query = String.Format(@"SELECT DISTINCT Column2 FROM MyTable WHERE Column1 = '{0}' ORDER Y Column2", cboMyComboBox.Text);
    
    	//Create the connection and commmand objects, then open a connection to the DB.
        SqlConnection conn = new SqlConnection(connString);        
        SqlCommand cmd = new SqlCommand(query, conn);
        conn.Open();
    
    	//Retrieve the data and fill the datatable
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dattab);
    	
    	//Close off connections
        conn.Close();
        da.Dispose();
    }
