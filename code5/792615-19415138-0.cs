    public TKey ExecuteScalar<TKey> ( string commandText, IDictionary<string, object> parameters )
    {
        using ( var connection = _connectionProvider.GetOpenConnection() )
        {
            using ( var command = connection.CreateCommand() )
            {
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;
                foreach ( var parameter in parameters )
                {
                    command.Parameters.Add( new SqliteParameter( parameter.Key, parameter.Value ?? DBNull.Value ) );
                }
                if (typeof (TKey) != typeof (int))
                {
                    return (TKey) command.ExecuteScalar();
                }
                    var executeScalar = command.ExecuteScalar();
                    var item = executeScalar == null ? 0 : 1;
                    return (TKey)(object)item;
            }
        }
    }
