    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    namespace My.Services
    {
        public class MyRouteHander : IRouteHandler
        {
		     ApplicationDbContext Db = new ApplicationDbContext();
             public IHttpHandler GetHttpHandler(RequestContext requestContext)
             {
			
			     // Get route data values
                 var routeData = requestContext.RouteData;
                 var action = routeData.GetRequiredString("action");
                 var controller = routeData.GetRequiredString("controller");
            
			     // Get webconfig settings
                 var webConfigSetting = ConfigurationManager.AppSettings["SOME_FANCY_SETTING"]
			     if (!string.IsNullOrEmpty(webConfigSetting))
			     {
			     	requestContext.RouteData.Values["action"] = webConfigSetting;
			     	return new MvcHandler(requestContext);
			     }
			
			     // If we have SomeDataBaseTable hit we do something else.
			     if (Db.SomeDataBaseTable.Any(x => x.Action == action))
                 {
                     // Lets do something with the requestContext.
                     string actionName = "SpecialAction";
                     requestContext.RouteData.Values["action"] = actionName;
                     requestContext.RouteData.Values["controller"] = "SpecialController";
                     requestContext.RouteData.Values.Add("id", Db.SomeDataBaseTable.FirstOrDefault(x => x.Action == action).Id);
                 }
                 return new MvcHandler(requestContext);
             }
         }
     }
