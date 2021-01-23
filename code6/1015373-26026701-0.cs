    public static class ApiControllerExtensions
    {
        public static string GetTemplatedHref(this ApiController controller, string routeName, string controllerName = "")
        {
            var routeTemplate = controller.Configuration.Routes[routeName].RouteTemplate;
            var baseUri = new Uri(controller.Request.RequestUri.GetLeftPart(UriPartial.Authority));
            var templatedHref = new Uri(baseUri, routeTemplate).ToString();
            return string.IsNullOrEmpty(controllerName) ? 
                templatedHref : 
                templatedHref.Replace("{controller}", controllerName.ToLower());
        }
    }
