    public class XyzController : ApiController
    {
        private readonly IDbContext _dbContext;
        public XyzController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        [Route("this-is-optional")]
        public IHttpActionResult Get(<optional-params-here>)
        {
            // Do work
            ...
         
            // My data is an array of objects
            return Ok(data);
        }
    }
    [TestFixture]
    public class XyzControllerTest
    {
        [Test]
        public void Get_ReturnsSuccessfully()
        {
            // Arrange
            IDbContext testContext = MockDbContext.Create();
            ...
            // Populate textContext here
            ...
            XyzController xyzController = new XyzController(testContext)
            {
                // These are required or exceptions will be thrown
                Request = new HttpRequestMessage();
                Configuration = new HttpConfiguration()
            };            
            ...
            // Act
            var response = xyzController.Get(<params-if-required>).ExecuteAsync(CancellationToken.None);
            // Assert
            Assert.IsNotNull(response);
			Assert.IsTrue(response.IsCompleted);
			Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            // Assertions on returned data
            MyModel[] models;
			Assert.IsTrue(response.Result.TryGetContentValue<MyModel[]>(out models));
			Assert.AreEqual(5, model.Count());
			Assert.AreEqual(1, model.First().Id);
            ...
        }
    }
    
