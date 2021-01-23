    [assembly: OwinStartup(typeof(WebApp.Initialization.OwinStartup))]
    namespace WebApp.Initialization
    {
        public class OwinStartup
        {
            public static IBus Bus { get; private set; }
    
            public void Configuration(IAppBuilder app)
            {
                BootStrapper();
             
                var resolver = ObjectFactory.GetInstance<IDependencyResolver>();
    
                var config = new HubConfiguration
                {
                    Resolver = resolver
                };
    
                app.MapSignalR(config);
            }           
    
            public static void ConfigureNServiceBus()
            {
                Bus = Configure.With()
                    .StructureMapBuilder(ObjectFactory.Container)
                    .MsmqSubscriptionStorage()
                    .PurgeOnStartup(false)
                    .UnicastBus()
                    .ImpersonateSender(false)
                    .CreateBus()
                    .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());
            }   
        }
    }
