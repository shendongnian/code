    public void DynamicConnectionExample(string entityConnectionString)
    {
        DbConnection dbConnection = new EntityConnection(entityConnectionString);
        bool shouldImplicitlyDisposeOfConnection = true;
        using (var ctx = new MyModelContext(dbConnection, shouldImplicitlyDisposeOfConnection))
        {
            // do stuff...
        }
     }
