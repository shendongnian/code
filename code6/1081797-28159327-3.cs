    public class Subject
    {
        public void ThrowMyException(int someState)
        {
            throw new MyException(someState);
        }
        public void ThrowSomeOtherException()
        {
            throw new InvalidOperationException();
        }
    }
    public class MyException : Exception
    {
        public int SomeState { get; private set; }
        public MyException(int someState)
        {
            SomeState = someState;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subject = new Subject();
            var exceptionThrown = xAssert.Throws<MyException>(() => { subject.ThrowMyException(123); });
            
            Assert.AreEqual(123, exceptionThrown.SomeState);
        }
    }
