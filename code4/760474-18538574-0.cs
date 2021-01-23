    public class Service1 : IService1, ILandingPage
        {
    ...
    ...
    
    public static void Configure(ServiceConfiguration serviceConfig)
            {
                //Still continue to load the service configuration from your web.config file as before.
                serviceConfig.LoadFromConfiguration();
                //Remove the serviceDebug behavior. 
                serviceConfig.Description.Behaviors.Remove<ServiceDebugBehavior>();
            }
    }
