    public static IEnumerable<IDbDataParameter> BuildParameters(this IDbCommand command, params KeyValuePair<string, DbType>[] parameters)
    {
        foreach(KeyValuePair<string, DbType> kvpParam in parameters)
        {
            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = kvpParam.Key;
            param.DbType = kvpParam.Value;
            yield return param;
        }
    }
