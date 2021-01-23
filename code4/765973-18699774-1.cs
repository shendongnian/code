    public interface IPluginComponent
    {
    }
    [TestClass]
    public abstract class BaseTests
    {
        protected abstract IPluginComponent CreateComponent();
        
        [TestMethod]
        public void SomeTest()
        {
            IPluginComponent component = this.CreateComponent();
            
            // execute test
        }
    }
    public class MyPluginComponent : IPluginComponent
    {
    }
    [TestClass]
    public class MyPluginTests : BaseTests
    {
        protected IPluginComponent CreateComponent()
        {
            return new MyPluginComponent();
        }
        
        [TestMethod]
        public void CustomTest()
        {
            // custom test
        }
    }
