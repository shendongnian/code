    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new UnityContainer();
            container.RegisterType<IFilterProvider, UnityFilterProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFilterProvider, UnityGlobalFilterProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<IGlobalFilterRegistrationList, GlobalFilterRegistrationList>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<I, C>();
            container.RegisterType<IActionFilter, SomeActionFilterAttribute>();
            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalFilters.Filters.Add(new SomeGlobalFilterAttribute());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
    public interface I
    { }
    public class C : I
    { }
    public class SomeGlobalFilterAttribute : ActionFilterAttribute
    {
        [Dependency]
        public I C { get; set; }
        public SomeGlobalFilterAttribute()
        {
            
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var c = C;
            base.OnActionExecuting(filterContext);
        }
    }
    public class SomeActionFilterAttribute : ActionFilterAttribute
    {
        [Dependency]
        public I C { get; set; }
        public SomeActionFilterAttribute()
        {
            
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var c = C;
            base.OnActionExecuting(filterContext);
        }
    }
