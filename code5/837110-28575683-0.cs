    private void button1_Click(object sender, EventArgs e)
    {
    	string folder = @"G:\Developers\Folder";
    	ReproProblem(folder);
    }
    
    static string oledbProviderString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"{0}\";Extended Properties=\"Text;HDR=No;FMT=Delimited\"";
    
    private void ReproProblem(string folderPath)
    {
    	using (OleDbConnection oledbConnection = new OleDbConnection(string.Format(oledbProviderString, folderPath)))
    	{
    		string sqlStatement = "Select * from [Book1.csv]";
    		//open the connection
    		oledbConnection.Open();
    		//Create an OleDbDataAdapter for our connection
    		OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStatement, oledbConnection);
    		//Create a DataTable and fill it with data
    		DataTable table = new DataTable();
    		adapter.Fill(table);
    		//close the connection
    		oledbConnection.Close();
    	}
    }
