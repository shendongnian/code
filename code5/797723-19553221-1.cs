    [TestFixture]
    public class TestRefDataProvider
    {
		private Mock<ICrmServiceClient> crmServiceClientMock;
        private IReferenceDataProvider _referenceDataProvider;
        [SetUp]
        public void SetUp()
        {
			crmServiceClientMock = new Mock<ICrmServiceClient>();
			crmServiceClientMock
				.Setuo(/* your code */)
				.Returns(/* your code */);
            _referenceDataProvider = new ReferenceDataProvider(
				crmServiceClientMock.Object
				);
        }
    }
