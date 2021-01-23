    [TestFixture]
    public class WindsorTests
    {
        [Test]
        public void LifecycleWarningTest()
        {
            IWindsorContainer container = new WindsorContainer();
            container.Register(
                    Component.For<ISingleton>().ImplementedBy<Singleton>().LifestyleSingleton(),
                    Component.For<ITransient>().ImplementedBy<Transient>().LifestyleTransient()
                );
            ISingleton singleton = container.Resolve<ISingleton>();
        }
    }
    interface ISingleton
    {
    }
    class Singleton : ISingleton
    {
        private readonly ITransient _transient;
        public Singleton(ITransient transient)
        {
            _transient = transient;
        }
    }
    interface ITransient
    {
    }
    class Transient : ITransient
    {
    }
