    while (sqlDataReader.Read())
    {
        long id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("ID"));
        string accountName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ACCOUNT_NAME"));
        long sequenceId = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("SEQUENCE_ID"));
        var idName = new Dictionary<long, string>();
        idName.Add(id, accountName);
        // Make sure that here you don't have repetitions of idName
        // or the next line will bomb with the exact same exception
        AccountTypeDic.Add(idName, sequenceId);
    }
