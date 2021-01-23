    [Export(typeof(IFoo))]
    public class Foo : IFoo
    {
        
    }
    [Export(typeof(IBar), ExportScope.Transient)]
    public class Bar : IBar
    {
        
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNinjectConventions()
        {
            var kernel = new StandardKernel();
            kernel.BindExportsInAssembly(typeof(IFoo).Assembly);
            kernel.Get<IFoo>().Should().Be(kernel.Get<IFoo>());
            kernel.Get<IBar>().Should().NotBe(kernel.Get<IBar>());
        }
    }
