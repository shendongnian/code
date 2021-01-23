    //You should be disposing the SqlCommand, I also switched constructors so I could re-use the SqlCommand.
    using(SqlCommand command = new SqlCommand())
    {
        command.Connection = connection;
        var scripts = Regex.Splt(script, "^\w+GO$", RegexOptions.Multiline);
        foreach(var splitScript in scripts)
        {
            command.CommandText = splitScript;
            command.ExecuteNonQuery();
        }
    }
