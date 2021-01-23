    public someobject GetData(/*arguments*/, string dbType)
    {
        var connectionString = dbType == 'dataBase1'  
        ? ConfigurationManager.ConnectionString['dataBase1'].toString() 
        : ConfigurationManager.ConnectionString['dataBase2'].toString()
        /*then pass connectionString to dbContext*/
        var dbContext = new DbContext(connectionString);
    }
