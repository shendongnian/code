    public interface IWpManagerFactory
    {
        WpManager BuildWpManager();
    }
    public sealed class Tests
    {
        public void Test()
        {
            var manager = new Mock<WpManager>();
            //Set up mock manager here...
            var factory = new Mock<IWpManagerFactory>();
            factory.Setup(f => f.BuildWpManager()).Returns(manager.Object);
            //Inject factory to class under test and execute the method under test...
        }
    }
