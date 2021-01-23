    public interface SomeTestInterface
    {
        void TestConnection();
    }
    [TestClass]
    public abstract class BaseTestClass : SomeTestInterface
    {
        [TestMethod]
        public void TestConnection()
        {
        }
        [TestMethod]
        public void TestQueryBase()
        {
            TestQuery();
        }
        public abstract void TestQuery();
    }
    [TestClass]
    public class ConcreteClassA : BaseTestClass
    {
        public override void TestQuery()
        {
            
        }
    }
