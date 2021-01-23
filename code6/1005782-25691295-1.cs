    [TestFixture]
    public class SubclassTests
    {
        [Test]
        public void Test()
        {
            var sut = new CSGetBuyerAbuseReportsRequestTanslatorTSS();
            
            //arrange your system under test here
            //...
            var result = sut.ExposeBusinessToService(service, value);
            Assert.AreEqual(expectedResult, result);
        }
    }
