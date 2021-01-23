    private const string SOLR_CONNECTION = "http://localhost:9001/solr/collection1";
    [ClassInitialize]
    public static void TestInitialize(TestContext context)
    {
        Startup.Init<Product>(SOLR_CONNECTION);
    }
