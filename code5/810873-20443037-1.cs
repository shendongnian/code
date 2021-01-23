    public override System.Data.IDbConnection Db
    {
        get
        {
            try
            {
                var d = base.Db;
                if (d == null || d.State != System.Data.ConnectionState.Open)
                    return  ForceNewDbConn();
                else
                    return d;
            }
            catch (Exception ex)
            {
                return ForceNewDbConn();
                //throw;
            }
        }
    }
    private IDbConnection ForceNewDbConn()
    {
        try
        {
            var f = TryResolve<IDbConnectionFactory>();
            if (f as OrmLiteConnectionFactory != null)
            {
                var fac = f as OrmLiteConnectionFactory;
                fac.AutoDisposeConnection = true;
                var newDBconn = fac.Open();
                return newDBconn;
            }
            return base.Db;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
