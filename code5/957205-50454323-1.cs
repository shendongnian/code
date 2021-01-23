    //WRONG NAME
    public VisitProcessor([Named("DataWarehouse")] IDbConnectionFactory connection)
        {
            _database = connection;
        }
