    using (OleDbConnection con = new OleDbConnection(connectionString))
    using (OleDbCommand cmd = new OleDbCommand(str, con))
    {
       con.Open();
       using (OleDbDataReader dr = cmd.ExecuteReader())
       {
    
       }
    }
