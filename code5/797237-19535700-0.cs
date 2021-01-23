    public void SubmitClick(Object sender, EventArgs e )
    {
        insertdata(FN.Text,LN.Text,DOB.Text,mailid.Text,username.Text);
    }
    
    public void insertdata(string fname, string sname, string dob ,string email ,string uname)
    {
        string database = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:\Users\atchutharamkj\documents\visual studio 2010\Projects\WebApplication1\WebApplication1\App_Data\Database3.accdb;Persist Security Info=True";
        OleDbConnection myConn = new OleDbConnection(database);
    
        string queryStr = @"Insert into Registration Values (?, ?, ?, ?, ?)";
    
        OleDbCommand myCommand = new OleDbCommand(queryStr, myConn);
        myCommand.Parameters.AddWithValue("@fname", fname);
        myCommand.Parameters.AddWithValue("@sname", sname);
        myCommand.Parameters.AddWithValue("@dob", dob);
        myCommand.Parameters.AddWithValue("@email", email);
        myCommand.Parameters.AddWithValue("@uname", uname);
    
        myCommand.Connection.Open();
        myCommand.ExecuteReader();
        myCommand.Connection.Close();
    }
