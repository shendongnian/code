    while (sqlDataReader.Read())
    {
        var idName = new Dictionary<long, string>(); 
        long id = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("ID"));
        string accountName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ACCOUNT_NAME"));
        idName.Add(id, accountName);
        long sequenceId = sqlDataReader.GetInt64(sqlDataReader.GetOrdinal("SEQUENCE_ID"));
        AccountTypeDic.Add(idName, sequenceId);
    }
