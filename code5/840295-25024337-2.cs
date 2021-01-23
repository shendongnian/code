    [TestFixture]
    public class ManagerTest
    {
        [Test]
        public void SomeTest()
        {
            var barMock = Mock<IBar>();
            var fooMock = Mock<IFoo>(barMock.Object);
            var managerUnderTest = new Manager(fooMock.Object);
            
            //proceed with test
        }
    }
