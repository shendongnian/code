    public class Bootstrapper : WindsorNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IWindsorContainer container)
        {
            container = new WindsorContainer();
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient);
           _container.Register(Component.For<ILog>().ImplementedBy<FileConsoleLog>());
        }
    }
  
