    using System.Web.Http;
    using System.Web.Http.OData.Builder;
    using ReproPatchNotWork.Models;
    
    namespace ReproPatchNotWork
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                config.MapHttpAttributeRoutes();
    
                ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
                builder.EntitySet<Announcement>("Announcements");
                config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
            }
        }
    }
