    public IEnumerable Provider()
    {
        yield return new OurApp.Data.SqlServer.DbProvider();
        yield return new OurApp.Data.Sqlite.DbProvider();
    }
    
    [Test]
    public void MyTest([ValueSource("Providers")] IDbProvider provider)
    {
        // Test code...
    }
