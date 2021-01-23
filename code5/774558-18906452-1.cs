    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().Configure(ConfigureControllers()));
            container.Register(
                Component
                    .For<IControllerFactory>()
                    .ImplementedBy<ControllerFactory>()
                    .LifeStyle.Singleton
            );
        }
        private ConfigureDelegate ConfigureControllers()
        {
            return c => c.LifeStyle.Transient;
        }
        private BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromAssemblyContaining<TicketsController>()
                .BasedOn<IController>()
                .If(t => t.Name.EndsWith("Controller"));
        }
    }
