    [TestClass]
    public class BaseIntegrationTest
    {
        protected readonly ApplicationDbContext _dbContext;
    
        public BaseIntegrationTest()
        {
            _dbContext = new ApplicationDbContext("DefaultConnectionTest");
             InsertTestData();
        }
    
        public void InsertTestData()
        {
            _dbContext.Users.Add(new User { Name = "John Doe" });
        }
    }
