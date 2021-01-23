    using System;
    using System.Collection.Generic;
    using System.Linq;
    using System.Web;
    using System.Http;
    using System.Mvc;
    using System.Routing;
    using System.Optimization;
    namespace MyProject
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            // ** This line right below might be what you are missing **
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
