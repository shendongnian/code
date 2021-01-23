    [TestClass]
    public class BaseIntegrationTest
    {
        private static bool _testsInitialized = false;
    
        protected readonly ApplicationDbContext _dbContext;
    
        public BaseIntegrationTest()
        {
            if(!_testsInitialized) {
                _dbContext = new ApplicationDbContext("DefaultConnectionTest");
                 InsertTestData();
                _testsInitialized = true;
            }
        }
    
        public void InsertTestData()
        {
            _dbContext.Users.Add(new User { Name = "John Doe" });
        }
    }
