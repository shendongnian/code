    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            // Create a mock of your interface and make the methods verifiable.
            var mock = new Mock<ISomeDependency>();
            mock.Setup(m => m.DoSomething())
                .Verifiable();
    
            // Setup your class which you expect to be calling the verifiable method
            var classToTest = new SomeClass(mock.Object);
            classToTest.DoWork();
    
            // Verify the method is called
            mock.Verify(m => m.DoSomething());
        }
    }
    
    
    
    public class SomeClass
    {
        private readonly ISomeDependency _someDependency;
    
        public SomeClass(ISomeDependency someDependency)
        {
            _someDependency = someDependency;
        }
    
        public void DoWork()
        {
            _someDependency.DoSomething();
        }
    }
    
    public interface ISomeDependency
    {
        void DoSomething();
    }
    
    public class SomeDependency : ISomeDependency
    {
        public void DoSomething()
        {
                
        }
    }
