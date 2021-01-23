    public class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            // Register unity controller factory to resolve controllers
            container.RegisterType<IControllerFactory, UnityControllerFactory>();
            // default registrations
            container.RegisterType<IStackOverFlowService, StackOverflowService>();
            // Do special registration per domain
            LocalHostRegistrations(container);
            SomeThingElseRegistrations(container);
            return container;
        }
        private static void LocalHostRegistrations(IUnityContainer container)
        {
            // you can create a child container per domain
            var localHostContainer = container.CreateChildContainer();
            // all special registrations for localhost go in this container
            // any registrations that are the same as the default we can leave off and unity will 
            //  auto find them from the parent
            localHostContainer.RegisterType<IStackOverFlowService, LocalHostStackOverflowService>();
            // register the child container in the parent container with a registration name
            container.RegisterInstance(typeof(IUnityContainer), "localhost", localHostContainer);
        }
        private static void SomeThingElseRegistrations(IUnityContainer container)
        {
            var localHostContainer = container.CreateChildContainer();
            localHostContainer.RegisterType<IStackOverFlowService, CustomStackOverflowService>();
            container.RegisterInstance(typeof(IUnityContainer), "somethingelse", localHostContainer);
        }
    }
