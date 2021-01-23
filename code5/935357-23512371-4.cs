    DbProviderFactory factory;
    private void Query(String query,Dictionary<String,object> namesAndValues)
    {
        factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
        using (DbConnection connection = factory.CreateConnection())
        {
            connection.ConnectionString = "your connectionstring here";
            connection.Open();
            DbCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.CommandType = System.Data.CommandType.Text;
            AddParameter(command, namesAndValues);
            DbDataReader reader=command.ExecuteReader();
            while (reader.Read())
            {
             //
            }
        }
    }
    private void AddParameter(DbCommand command, Dictionary<String, object> namesAndValues)
    {
        String factoryName = factory.GetType().Name;
        DbParameter para;
        foreach (String key in namesAndValues.Keys)
        {
            para = command.CreateParameter();
            switch (factoryName)
            {
                case "SqlClientFactory":
                    para.ParameterName = "@" + key;
                    break;
                 case "OracleClientFactory":
                    para.ParameterName = ":" + key;
                    break;
                case "OleDbFactory":
                    para.ParameterName = "?";
                    break;
                case "MySqlClientFactory":
                    para.ParameterName = "?" + key;
                    break;
            }
            para.Value = namesAndValues[key];
            command.Parameters.Add(para);
               
        }
    }
