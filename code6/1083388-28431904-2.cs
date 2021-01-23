    var script = objectContext.CreateDatabaseScript();
    using ( var command = connection.CreateCommand() )
    {
        command.CommandType = CommandType.Text;
        command.CommandText = script;
        connection.Open();
        command.ExecuteNonQuery();
    }
