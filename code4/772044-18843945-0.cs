    using (OleDbConnection con = new SqlConnection(connectionString))
    using (OleDbCommand cmd = new OleDbCommand(str, con))
    {
       cmd.CommandTimeout = 120;
       con.Open();
       using (OleDbDataReader dr = cmd.ExecuteReader())
       {
    
       }
    }
