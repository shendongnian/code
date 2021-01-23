    public  void ExecuteAccessQurey(string _pQurey)
    {
        OleDbConnection con = new OleDbConnection("DatabaseConnectionString");
        OleDbCommand cmd = new OleDbCommand(_pQurey, con);
        if (con.State == System.Data.ConnectionState.Closed)
        {
            con.Open();
        }
        cmd.ExecuteNonQuery();
        con.Close();
    }
