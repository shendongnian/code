    [TestFixture]
    public class ReflectionTests
    {
        [Test]
        public void Test()
        {
            var sut = new CSGetBuyerAbuseReportsRequestTanslator();
            
            //arrange your system under test here
            //...
            var result = sut.GetType()
                            .GetMethod("BusinessToService", BindingFlags.NonPublic)
                            .Invoke(result, new [] {service, value});
            Assert.AreEqual(expectedResult, result);
        }
    }
