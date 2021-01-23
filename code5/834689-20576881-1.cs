    public List<T> SelectSqlItems<T>(
        string settingsgroup = null,
        int? state = null)
    {
        var cmdText = "..."; // See Query Below
        var selectCommand = new SqlCommand(cmdText, con);
        // Set the values of the parameters
        selectCommand.Parameters.AddWithValue("@settingsgroup", settingsgroup);
        selectCommand.Parameters.AddWithValue("@state", state);
        // etc...
    }
