    public class MvcApplication : System.Web.HttpApplication
    {
        public static StructureMapDependencyResolver StructureMapResolver { get; set; }
        protected void Application_Start()
        {
            ...
 
            // Setup your Container before 
            var container = IoC.Initialize();
            StructureMapResolver = new StructureMapDependencyResolver(container);
            DependencyResolver.SetResolver(StructureMapResolver);
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            StructureMapResolver.CreateNestedContainer();
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            StructureMapResolver.DisposeNestedContainer();
        }    
    }
