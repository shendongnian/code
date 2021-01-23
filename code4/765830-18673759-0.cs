        try
    {
    string connStr =( @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\test.accdb;Persist Security Info=False");
    OleDbConnection conn1 = new OleDbConnection();
    conn1.ConnectionString = connStr;             
    
    OleDbCommand cmd = conn1.CreateCommand();
    cmd.CommandText = "INSERT INTO customer (id, name)" + " VALUES('3', 'C');";
    
    conn1.Open();
    cmd.ExecuteNonQuery();
    }
    catch(Exception e)
    {
     //print the message you want;
    }
