    // NUnit test fixture - untested, please forgive any typos
    [TestFixture]
    public class AutofacComprehensionTest
    {
        internal interface ICacheManager {}
        internal class ConcreteCacheManager : ICacheManager {}
        
        [Test]
        public void SingleInstance_causes_same_instance_to_be_returned_for_each_request()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConcreteCacheManager>().As<ICacheManager>().SingleInstance();
            var container = builder.Build();
            var first = container.Resolve<ICacheManager>();
            var second = container.Resolve<ICacheManager>();
            Assert.That(first, Is.SameAs(second));
        }
    }
