    public static void OleDB_Query(string cmd, string[] vars = null, string[] vals = null)
    {
        using(OleDbConnection Connection = new OleDbConnection(connectionString))
        {
            Command.Connection.Open();
            using(OleDbCommand Command = new OleDbCommand(cmd, Connection))
            {
                if (vars != null) {
                    for (int k = 0; k < vars.Length; k++)
                        Command.Parameters.AddWithValue(vars[k], vals[k]);
                  
                    Command.ExecuteNonQuery();
            }
            Command.Connection.Close();            
        }
    }
