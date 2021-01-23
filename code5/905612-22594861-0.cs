    using(IDbConnection connection = new SybaseAseConnection()) //(I honestly can't remember the name)
    {
        connection.Open();
        IDbCommand command = connection.CreateCommand();
        command.CommandText = "SQL";
        using(IDbReader reader = command.ExecuteReader())
        {
             List<string> fieldNames = Enumerable.Range(0, reader.FieldCount)
                                       .Select(i => reader.GetName(i)).ToList(); 
        }
    }
    
