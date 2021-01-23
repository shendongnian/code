    //Its better to dispose the SqlCommand, I also switched constructors so I could re-use the SqlCommand.
    using(SqlCommand command = new SqlCommand())
    {
        command.Connection = connection;
        var scripts = Regex.Split(script, @"^\w+GO$", RegexOptions.Multiline);
        foreach(var splitScript in scripts)
        {
            command.CommandText = splitScript;
            command.ExecuteNonQuery();
        }
    }
