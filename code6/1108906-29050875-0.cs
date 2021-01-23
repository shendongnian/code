    using System;
    using System.Web.Mvc;
    public static class RouteHtmlHelpers
    {
        public static string GetRoutePrefix(this HtmlHelper helper)
        {
            // Get the controller type
            var controllerType = helper.ViewContext.Controller.GetType();
            // Get the RoutePrefix Attribute
            var routePrefixAttribute = (RoutePrefixAttribute)Attribute.GetCustomAttribute(
                controllerType, typeof(RoutePrefixAttribute));
            // Return the prefix that is defined
            return routePrefixAttribute.Prefix;
        }
    }
