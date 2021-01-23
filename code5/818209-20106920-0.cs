    public classDataBaseManager
    {
    ...
    public int ExecuteStoredProcedure(string storedprocedureNaam, IEnumerable<KeyValuePair<string, object>> parameters)
    {
        var sqlCommand = new SqlCommand
        {
            Connection = DatabaseConnectie.SqlConnection,
            CommandType = CommandType.StoredProcedure,
            CommandText = storedprocedureNaam,
        };
        foreach (KeyValuePair<string, object> keyValuePair in parameters)
        {
            sqlCommand.Parameters.Add(
                new SqlParameter { ParameterName = "@" + keyValuePair.Key, Value = keyValuePair.Value ?? DBNull.Value }
            );
        }
        if (sqlCommand == null)
            throw new KoppelingException("Stored procedure ({0}) aanroepen lukt niet", storedprocedureNaam);
        return sqlCommand.ExecuteNonQuery();
    }
    ....
    }
