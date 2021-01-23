    public static class CommandFactory
    {
        public static DbCommand CreateCommnad(DbConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandTimeout = ReadTimeoutFromConfig();
            //Set other properites to default values
            return cmd;
        }
    }
    ...
    using (var connection = new SqlConnection("Server=Server2;Database=;Trusted_Connection=true"))
    {
        using (var command = CommandFactory.CreateCommnad(connection))
        {
            command.CommandText = "...";
            //Execute a command, read results etc.
        }
    }
    ...
