    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<BaseService>()
                .BasedOn(typeof(IService))
                .WithService.AllInterfaces()
                .LifestyleTransient());            
        }
    }
    private static void BootstrapContainer()
    {
        container = new WindsorContainer();
        container.Install(new ServiceInstaller());
        container.Install(new ControllersInstaller());
        var controllerFactory = new WindsorControllerFactory(container.Kernel);
        ControllerBuilder.Current.SetControllerFactory(controllerFactory);
    }
