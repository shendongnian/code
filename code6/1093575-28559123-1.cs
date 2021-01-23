    public DataTable GetSpyList()
    {
        DbProviderFactory fac = DbProviderFactories.GetFactory("MySQL.Data.MySqlClient");
        DataTable dt = new DataTable();
        using(DbConnection conn = fac.CreateConnection()) 
        {
            cn.ConnectionString  = cs
            DbDataAdapter da = fac.CreateDataAdapter();
            da.SelectCommand = conn.CreateCommand();
            da.SelectCommand.CommandText = "SELECT * FROM SpyList";
            try
            {
                conn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
        
