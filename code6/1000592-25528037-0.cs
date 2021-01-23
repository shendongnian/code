    using System.Web.Mvc;
    
    namespace WebApplication1.Areas.Admin
    {
        public class AdminAreaRegistration : AreaRegistration 
        {
            public override string AreaName 
            {
                get 
                {
                    return "Admin";
                }
            }
    
            public override void RegisterArea(AreaRegistrationContext context) 
            {
                // This is where the custom route has to be registered for me to access
                // it from my area.
                context.MapRoute(
                    "Admin_pages",
                    "Admin/Pages/{action}/{id}",
                    new { action = "Index", 
                          controller = "CMSPages", 
                          id = UrlParameter.Optional }
                );
    
                context.MapRoute(
                    "Admin_default",
                    "Admin/{controller}/{action}/{id}",
                    new { action = "Index", id = UrlParameter.Optional }
                );
            }
        }
    }
