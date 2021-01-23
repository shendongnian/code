    public class Service
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
        }
        public static void OnStartup()
        {
            // add any startup logic here, like caching your data
        }
        public static void OnShutdown()
        {
            // add any cleanup logic here
        }
    }
