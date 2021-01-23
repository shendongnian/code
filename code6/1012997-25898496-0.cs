        [TestClass]
        public class MyTests
        {
           [TestMethod]
           [ExpectedEngineExceptionAttribute]
           public void MyTest()
           {
               throw new Exception("HI");
           }
         }
        public class ExpectedEngineExceptionAttribute : ExpectedExceptionBaseAttribute
        {
           protected override void Verify(Exception exception)
           {
               RethrowIfAssertException(exception);
               throw new Exception("Hola!!!");
           }
        }
