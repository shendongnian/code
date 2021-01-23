    private static SqlParameter[] DiscoverParameters(string connectionString, string spName)
    {
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(spName, connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            
            connection.Open();
            SqlCommandBuilder.DeriveParameters(command);
            connection.Close();
            
            return command.Parameters
                .Cast<ICloneable>()
                .Select(p => p.Clone())
                .Cast<SqlParameter>()
                .ToArray();
        }
    }
