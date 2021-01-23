    public class Global : Application
    {
        protected override Application_Start()
        {
            var container = new Container();
            container.RegisterMvcControllers();
            BusinessLayerBootstrapper.Bootstrap(container, new WebRequestLifestyle());
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
