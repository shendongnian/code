	[TestClass]
	public class TestCommandServiceTests
	{
		private readonly TestService> _testService;
		private readonly ITestRepositor _testRepository;
		private readonly Mock<IDatabaseLaye> _mock;
		[SetUp]
		public void Setup()
		{
			_mock = new Mock<IDatabaseLayer>();
			_testRepository = new TestRepository(_mock);
			_testService = new TestService(_testRepository);
		}
		[Test]
		public void TestMethod_ValidRequest_ShouldTestSuccessfully()
		{
			// Arrange
			var request = new TestMethodRequest();
			this._mock.Setup(c => c.Add(null)).Returns(1000);
			// Act
			var response = _testService.TestMethod(request);
			// Assert
			Assert.IsNotNull(response);
			Assert.AreEqual(1000, response.Id);
		}
	}
