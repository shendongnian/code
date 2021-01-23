    while (sqlDataReader.Read())
    {
        IdName.Clear();
        IdName.Add(Int64.Parse(sqlDataReader["ID"].ToString()),sqlDataReader["ACCOUNT_NAME"].ToString());
        AccountTypeDic.Add(IdName, Int64.Parse(sqlDataReader["SEQUENCE_ID"].ToString()));
    }
