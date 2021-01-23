    public void Connect(DbConnection dbConnection)
    {
        var sqlDbCon = dbConnection as SQLConnection;
        if(con != null)
        {
           //process here for SQLConnection
        }
    
        var vistaDbCon = dbConnection as VistaDbConnection;
        if(con != null)
        {
           //process here for VistaDbConnection
        }
    
    }
