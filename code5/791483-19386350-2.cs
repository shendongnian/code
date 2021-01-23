    [TestFixture(0)]
    [TestFixture(1)]
    public class RepositoryTests
    {
        private IDbProvider _provider;
    
        public IDbProvider(int index)
        {
            _provider = IDbProvider[index];
        }
    
        static IDbProvider[] DbProviders = new IDbProvider[] 
        {
            sqlserver.DbProvider,  
            sqlite.DbProvider
        };
        [Test]
        public void TestMethod(IDbProvider dbProvider)
        {
            ShouldDoStuff(_provider);
        }
    }
