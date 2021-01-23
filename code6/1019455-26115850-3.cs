    [TestClass]
    public class MyBusinessTests
    {
        [TestInitialize]
        public void Init()
        {
            DalFactory.Instance = TestDalFactory.Instance;
        }
    
        [TestMethod]
        public void do_some_testing_in_the_business()
        {
            TestDalFactory.Instance.DalInstances[typeof(CustomerDal)] = new MyNewMock();
    
            //do the testing here
        }
    }
