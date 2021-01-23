    [TestFixture]
    public class MyServiceTests {
        [TestFixture]
        public class GetCoordinates : MyServiceTests {
            // Given
            string expected = "Name";
            Coordinate[] coordinates = new Coordinate[] { ... }
            externalServiceClient.Setup(esc => esc.GetInformationForCoordinates(coordinates)).Returns(expected);
            // When
            string actual = myService.GetName(coordinates);
            // Then
            externalServiceClientMock.Verify(esc => esc.GetInformationCoordinates(coordinates));
            Assert.AreEqual(expected, actual);
        }
        [SetUp]
        public void MyServiceSetup() {
            externalServiceClient = new Mock<ExternalServiceClient>("WSHttpBinding_IMyService");
            myService = new MyService(externalServiceClientMock.Object);
        }
        
        private Mock<ExternalServiceClient> externalServiceClientMock;
        private MyService myService;
    }
