    DbConnection conn = null;
    switch (Type)
    {
       case ConnectionType.LocalDB:
          conn = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
          break;
       case ConnectionType.MySql:
          conn = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
          break;
       default:
          throw new System.InvalidOperationException();
    }
    conn.ConnectionString = "Add provider specific connection string here";
