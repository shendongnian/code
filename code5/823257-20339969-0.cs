    public override bool TableExists(string tableName)
    {
        var connection = GetConnection(true);
        try
        {
            using (var command = GetNewCommandObject())
            {
                command.Transaction = CurrentTransaction as SqlCeTransaction;
                command.Connection = connection;
                var sql = string.Format(
                        "SELECT COUNT(*) FROM information_schema.tables WHERE table_name = '{0}'", 
                         tableName);
                command.CommandText = sql;
                var count = Convert.ToInt32(command.ExecuteScalar());
                return (count > 0);
            }
        }
        finally
        {
            DoneWithConnection(connection, true);
        }
    }
