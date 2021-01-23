    var result = new DataSet();
    using(var myConnection = new MySqlConnection(sCon))
    {
        myConnection.Open();
        var myCommand = myConnection.CreateCommand();
        myCommand.CommandText = query;
        foreach (var p in pms)
            myCommand.Parameters.Add(p);
        var myAdapter = new MySqlDataAdapter(myCommand);
    
        myAdapter.Fill(result);
    }
    return result;
