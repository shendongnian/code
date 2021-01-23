    using(OleDbConnection Connection = new OleDbConnection(conString))
    using(OleDbCommand Command = Connection.CreateCommand())
    {
        Command.CommandText = "SELECT FTPTARIHARALIGI FROM Table1 WHERE ID = 1";
        using(OleDbDataReader reader = Command.ExecuteReader())
        {
            if(reader.Read())
            {
                int test = reader.GetInt32(0);
            }  
        }
    }
    
