    var direct = mydbContext.Database;
    using (var command = direct.Connection.CreateCommand())
    {
        if (command.Connection.State != ConnectionState.Open) 
        { 
            command.Connection.Open(); 
        }
        command.CommandText = query.ToString(); // Some query built with StringBuilder.
        command.Parameters.Add(new SqlParameter("@id", someId));
        using (var reader = command.ExecuteReader())
        {
            if (reader.Read()) 
            {
                ... code here ...
                reader.Close();
            }
            command.Connection.Close();
        }
    }
