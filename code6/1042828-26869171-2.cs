    private void Insert()
    {
        string ConnectionStringAccess = Provider=Microsoft.ACE.OLEDB.12.0;Data Source=###Jet OLEDB:Database Password=###;
        int id = -1;
        string Query = "INSERT INTO tblTable (EmpNo, Name) VALUES (132, 'TestName'); SELECT @@Identity";
        OleDbConnection con = new OleDbConnection(ConnectionStringAccess);
        OleDbCommand cmd = new OleDbCommand(Query, con);
        try
        {
            con.Open();
            id = int.Parse(cmd.ExecuteScalar().ToString());
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
