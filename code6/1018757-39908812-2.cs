    public static class Ioc
    {
        public static void Config()
        {
            var container = InitializeContainer();
            var webApiDependencyResolver = new StructureMapResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiDependencyResolver;
            var mvcDependencyResolver = new StructureMapDependencyResolver(container);
            DependencyResolver.SetResolver(mvcDependencyResolver);
        }
    }
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Ioc.Config();
            ...
        }
    }
