    public class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });
        // Gets the configured Unity container
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
        // Register type mappings
        public static void RegisterTypes(IUnityContainer container)
        {
            // LogManagerAdapter wrapping e.g. log4net
            container.RegisterType<ILogManager, LogManagerAdapter>();
            // AutoMapperAdapter wrapping e.g. AutoMapper
            container.RegisterType<IAutoMapper, AutoMapperAdapter>();
            
            // Interface for persisting the user
            container.RegisterType<IAddUserQueryProcessor, AddUserQueryProcessor>();
            // Interface for doing application logic in regards to adding a user
            container.RegisterType<IAddUserMaintenanceProcessor, AddUserMaintenanceProcessor>();
        }
    }
