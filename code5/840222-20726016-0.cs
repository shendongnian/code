    [TestFixture]
    [Isolated]
    public class TestCommandServiceTests
    {
        private TestService _testService;
        private ITestRepository _testRepository;
        private IDatabaseLayer _databaseLayer;
        [SetUp]
        public void Setup()
        {
            _databaseLayer = Isolate.Fake.Instance<IDatabaseLayer>();
            Isolate.Swap.NextInstance<IDatabaseLayer>().With(_databaseLayer);
            _testRepository = new TestRepository(_databaseLayer);
            _testService= new TestService(_testRepository);
        }
        [Test]
        public void TestMethod_ValidRequest_ShouldTestSuccessfully()
        {
            // Arrange
            var request = new TestMethodRequest();
            Isolate.WhenCalled(() => _databaseLayer.Add(null)).WillReturn(1000);
            // Act
            var response = _testService.TestMethod(request);
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(1000, response.Id);
        }
    }
