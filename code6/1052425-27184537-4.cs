    using(OleDbConnection Connection = new OleDbConnection(conString))
    using(OleDbCommand Command = Connection.CreateCommand())
    {
        Command.CommandText = "SELECT FTPTARIHARALIGI FROM Table1 WHERE ID = 1";
        Connection.Open();
        int test = (int)Command.ExecuteScalar();
    }
