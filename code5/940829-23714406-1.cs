    public abstract class BaseTest
    {
        public void Verify1()
        {
            // other code to do stuff
            Approvals.Verify(1);
        }
    }
    [TestClass]
    public class UnitTest1 : BaseTest
    {
        public UnitTest1()
        {
            // some initialization
        }
        [TestMethod]
        public void Test1()
        {
            Verify1();
        }
    }
