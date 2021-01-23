    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer _container;
        protected void Application_Start()
        {
            BootstrapContainer();
        }
        protected void Application_End(object sender, EventArgs e)
        {
            _container.Dispose();
        }
        private void BootstrapContainer()
        {
            _container = new WindsorContainer();
            // Registers all components from classes implementing 
            // IWindsorInstaller when classes defined in the web assembly, i.e.
            // ControllerInstaller
            _container.Install(FromAssembly.This());
            // You can also put this in a separate installer class and register
            // by convention
            _container.Register(
                Component
                    .For<ITicketRepository>()
                    .ImplementedBy<TicketEfRepository>()
                    .LifeStyle.Transient);
            ControllerBuilder.Current.SetControllerFactory(
                    _container.Resolve<IControllerFactory>());
        }
    }    
