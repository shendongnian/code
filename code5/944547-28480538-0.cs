    public class RouteProvider : IRouteProvider
    {
        private const string NAMESPACES = "Nop.Plugin.Misc.Custom.Controllers";
        private const string CONTROLLER = "MiscCustom";
     
        public void RegisterRoutes(RouteCollection routes)
        {     
            //Public Override
            routes.MapGenericPathRoute("Plugin.Misc.Custom.GenericUrl",
                "{generic_se_name}",
                new { controller = "Common", action = "GenericUrl" },
                new[] { NAMESPACES });
  
        }
     
        public int Priority
        {
            get { return -1; }
        }
    }
