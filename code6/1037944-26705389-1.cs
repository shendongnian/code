    public class TestAssembliesResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
    [TestMethod]
    public void TestMethod1()
    {
        // Replace the original IAssembliesResolver.
        GlobalConfiguration.Configuration.Services.Replace(typeof(IAssembliesResolver),
            new TestAssembliesResolver());
        var container = SimpleInjectorWebApiInitializer.BuildContainer();
        container.Verify();
    }
