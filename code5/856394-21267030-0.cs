    TdConnectionStringBuilder connectionStringBuilder = new TdConnectionStringBuilder();
    connectionStringBuilder.DataSource = "x";
    connectionStringBuilder.Database = "DATABASENAME";
    connectionStringBuilder.UserId = "y";
    connectionStringBuilder.Password = "z";
    connectionStringBuilder.AuthenticationMechanism = "LDAP";
    using (TdConnection cn = new TdConnection())
    {
        cn.ConnectionString = connectionStringBuilder.ConnectionString;
        cn.Open();
        TdCommand cmd = cn.CreateCommand();
        cmd.CommandText = "SELECT DATE";
        using (TdDataReader reader = cmd.ExecuteReader())
        {
            reader.Read();
            DateTime date = reader.GetDate(0);
            Console.WriteLine("Teradata Database DATE is {0}", date);
        }
    }
