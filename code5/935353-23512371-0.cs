        DbProviderFactory factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
        using (DbConnection connection = factory.CreateConnection())
        {
            connection.ConnectionString = "your connectionstring here";
            connection.Open();
            DbCommand command = connection.CreateCommand();
            command.CommandText = "SELECT x from y";
            command.CommandType = System.Data.CommandType.Text;
            DbDataReader reader=command.ExecuteReader();
            while (reader.Read())
            {
                //
            }
        }
