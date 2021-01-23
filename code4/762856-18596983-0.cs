    var scripts = Regex.Splt(script, `^GO$`, RegexOptions.Multiline);
    foreach(var splitScript in scripts)
    {
        using(SqlCommand command = new SqlCommand(script, connection))
        {
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
        }
    }
