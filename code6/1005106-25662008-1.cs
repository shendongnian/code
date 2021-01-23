    [TestFixture]
    public class PortManagerTests
    {
        [Test]
        public void PortsAreFree_APortIsLocked_ReturnsFalse()
        {
              var mock = new Mock<IPortChecker>();
              mock.Setup(x=> x.IsPortOpen(77)).Returns(false);
              
              var portManager = new PortManager(mock.Object);
              
              Assert.Equal(true, portManager.PortsAreFree(1, 76));
              Assert.Equal(true, portManager.PortsAreFree(78, 200));
              Assert.Equal(false, portManager.PortsAreFree(1, 200));
        }
    }
}
