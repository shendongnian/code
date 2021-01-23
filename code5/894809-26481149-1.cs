    EntityConnection entityConn =DBConnectionHelper.BuildConnection();
    using (var db = new TestEntities(entityConn.ConnectionString))
    {
    ....
    }
