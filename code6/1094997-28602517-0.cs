    public void executeQuery(string[] queries)
    {
        connection.Open();
     
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        foreach(string query in queries)
        {
          string con = query;
          command.CommandText = con;
          command.ExecuteNonQuery();
        }
        connection.close();
    }
    
