    [TestFixture]
    public class ManagerTest
    {
        [Test]
        public void SomeTest()
        {
            var fooMock = Mock<IFoo>();
            var managerUnderTest = new Manager(fooMock.Object);
        }
    }
