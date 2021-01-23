    private string filepath = @"C:\Users\sy\Visual Studio 2008\Projects\demo\demo\CE_Database.mdb";
    private string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;data source=" + filepath + ";";
	private void button1_Click(object sender, EventArgs e)
    {		
        if (this.Update() == 0)
        {
            this.Insert();
        }
    }
    private int Update()
    {	
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        using (OleDbCommand command = new OleDbCommand("UPDATE Table1 SET ID=value1,Team=value2 WHERE ID=value3", conn);
        {
            conn.Open();
            return command.ExecuteNonQuery();
        }
    }
	private int Insert()
	{		
        using (OleDbConnection conn = new OleDbConnection(connectionString))
        using (OleDbCommand command = new OleDbCommand("INSERT INTO Table1 (ID,Team) VALUES (value1,value2)", conn);
        {
            conn.Open();
            return command.ExecuteNonQuery();
        }
    }
