    namespace Blah.Web.Helpers
    {
        public static class HtmlHelpers
        {
            public static string IsActive(this IHtmlHelper htmlHelper, string controller, string action)
            {
                var routeData = htmlHelper.ViewContext.RouteData;
    
                var routeAction = routeData.Values["action"].ToString();
                var routeController = routeData.Values["controller"].ToString();
    
                return (controller == routeController && action == routeAction) ? "active" : "";
            }
        }
    }
