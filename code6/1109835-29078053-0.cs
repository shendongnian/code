    public abstract class MyBase
    {
        [Test]
        public void test1()
        {
            GetService().callmethod();
        }
        public abstract IService1 GetService();
    }
    [TestFixture]
    public class MyTest:MyBase
    {
        private IService2 service;
      
        [SetUp]
        public void setup()
        {
            service = A.Fake<IService2>();
        }
        public override IService1 GetService()
        {
            return service;
        }
    }
