    public class FooInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container,
            IConfigurationStore store)
        {
            container.Register(Component.For<IFoo>().ImplementedBy<Foo>().LifeStyle.Transient);
        }
    }
