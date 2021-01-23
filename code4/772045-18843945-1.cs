    using (OleDbConnection con = new OleDbConnection(connectionString))
    using (OleDbCommand cmd = new OleDbCommand(str, con))
    {
       con.ConnectionTimeout = 120;
       con.Open();
       using (OleDbDataReader dr = cmd.ExecuteReader())
       {
    
       }
    }
