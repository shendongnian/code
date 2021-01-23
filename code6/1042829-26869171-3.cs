    private void Insert()
    {
        string ConnectionStringAccess = Provider=Microsoft.ACE.OLEDB.12.0;Data Source=###Jet OLEDB:Database Password=###;
        int id = -1;
        string Query = "INSERT INTO tblTable (EmpNo, Name) VALUES (132, 'TestName')";
        string Query2 = "SELECT @@Identity";
        OleDbConnection con = new OleDbConnection(ConnectionStringAccess);
        OleDbCommand cmd = new OleDbCommand(Query, con);
        OleDbCommand cmd2 = new OleDbCommand(Query2, con);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            id = (int)cmd2.ExecuteScalar();
        }
        catch (Exception ex)
        {
            //log the ex
        }
        finally
        {
            con.Dispose();
            con.Close();
        }
    }
