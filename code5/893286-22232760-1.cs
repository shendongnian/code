    [global:Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class MyTestClass
    {
        [global::Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void MyTestMethod()
        {
            //Arrange
            var mock = new Mock<USZipSoap>();
            var proxy = new ProxyHandler(mock.Object);
            //Act
            var result = proxy.GetZipInfo();
            //Assert
            mock.Verify(m => m.GetInfoByZIP("20008"), Times.Once, "Error");
        }
    }
