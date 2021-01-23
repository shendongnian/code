    using(MySqlConnection myConnection = new MySqlConnection(sConnection))
    using(MySqlCommand myCommand = myConnection.CreateCommand())
    {
        myConnection.Open();
        myCommand.CommandText = query;
        foreach (var p in sqlParams)
            myCommand.Parameters.Add(p);
        using(MySqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
        {
            dt.Load(myReader);
        }
    }
