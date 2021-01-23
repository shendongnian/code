    static IDbProvider[] DbProviders = new IDbProvider[] 
    {
        sqlserver.DbProvider,  
        sqlite.DbProvider
    };
    [Test, TestCaseSource("DbProviders")]
    public void TestMethod(IDbProvider dbProvider)
    {
        ShouldDoStuff(dbprovider);
    } 
