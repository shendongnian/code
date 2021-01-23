    void OnRowUpdated(object sender, MySqlRowUpdatedEventArgs args)
    {
        string sql = args.Command.CommandText;
        bool isStoredProcedure = args.Command.CommandType == CommandType.StoredProcedure;
        foreach (MySql.Data.MySqlClient.MySqlParameter p in args.Command.Parameters)
        {
            string paramName = p.ParameterName;
            DbType dbType = p.DbType;
            MySqlDbType dbType2 = p.MySqlDbType;
            object value = p.Value;
        }
    }
