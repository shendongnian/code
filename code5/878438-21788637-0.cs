    public class ContainerBootstrapper {
        public static void RegisterTypes(IUnityContainer container) {
            container.RegisterType<ICustomer, CustomerImplementation>(/* configure your class implementation here */);
            container.RegisterType<ISiteSettings, SettingsImplementation>(...);
            container.RegisterType<ILogger, LoggerImplementation(...));
            ...
        }
    }
