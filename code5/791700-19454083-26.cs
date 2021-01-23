    private constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=yourdbfile.mdb;Jet OLEDB:Database Password=yourpassword;";
    
    OleDbConnection conn = new OleDbConnection(constr);
    
    string query = "SELECT * FROM [YourTable]";
        
    OleDbCommand cmd = new OleDbCommand(query, conn);
    OleDbDataReader reader = cmd.ExecuteReader();
    int rowNum = 0;
    StringBuilder sb = new StringBuilder(); 
    while (reader.Read())
    {
       // write rows to flat file in chunks of 10K rows.
       sb.Append(reader["FieldA"].ToString() + "|");
       sb.Append(reader["FieldB"].ToString() + "|");
       sb.Append(reader["FieldC"].ToString() + System.Environment.NewLine);
      
       if (rowNum % 10000 == 0)
       {
    		File.AppendText(@"c:\temp\data.psv", sb.ToString());
    		sb = new StringBuilder(); 
       }
       rowNum++;
    }
    File.AppendText(@"c:\temp\data.psv", sb.ToString());
    reader.Close();
