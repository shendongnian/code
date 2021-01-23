    [TestFixture]
    public class RepositoryTests
    {
        protected IDbConnectionProvider Connection_SQLServer;
        protected IDbConnectionProvider Connection_SQLLite;
        protected string testDatabaseName_SQLServer;
        protected string testDatabaseName_SQLLite;
        [SetUp]
        public void Setup()
        {
            // init both providers and db-names
        }
    
        public IEnumerable Providers()
        {
            yield return new SqlServer.DbProvider(testDatabaseName_SQLServer, Connection_SQLServer);
            yield return new Sqlite.DbProvider(testDatabaseName_SQLLite, Connection_SQLLite);
        }
    
        // Do tests
