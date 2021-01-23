    public static class GenericUrlActionHelper {
        /// <summary>
        /// Generates a fully qualified URL to an action method 
        /// </summary>
        public static string Action<TController>(this UrlHelper urlHelper, Expression<Action<TController>> action)
           where TController : Controller {
            RouteValueDictionary rvd = InternalExpressionHelper.GetRouteValues(action);
            return urlHelper.Action(null, null, rvd);
        }
        public const string HttpAttributeRouteWebApiKey = "__RouteName";
        public static string HttpRouteUrl<TController>(this UrlHelper urlHelper, Expression<Action<TController>> expression)
           where TController : System.Web.Http.Controllers.IHttpController {
            var routeValues = expression.GetRouteValues();
            var httpRouteKey = System.Web.Http.Routing.HttpRoute.HttpRouteKey;
            if (!routeValues.ContainsKey(httpRouteKey)) {
                routeValues.Add(httpRouteKey, true);
            }
            var url = string.Empty;
            if (routeValues.ContainsKey(HttpAttributeRouteWebApiKey)) {
                var routeName = routeValues[HttpAttributeRouteWebApiKey] as string;
                routeValues.Remove(HttpAttributeRouteWebApiKey);
                routeValues.Remove("controller");
                routeValues.Remove("action");
                url = urlHelper.HttpRouteUrl(routeName, routeValues);
            } else {
                var path = resolvePath<TController>(routeValues, expression);
                var root = getRootPath(urlHelper);
                url = root + path;
            }
            return url;
        }
        private static string resolvePath<TController>(RouteValueDictionary routeValues, Expression<Action<TController>> expression) where TController : Http.Controllers.IHttpController {
            var controllerName = routeValues["controller"] as string;
            var actionName = routeValues["action"] as string;
            routeValues.Remove("controller");
            routeValues.Remove("action");
            var method = expression.AsMethodCallExpression().Method;
            var configuration = System.Web.Http.GlobalConfiguration.Configuration;
            var apiDescription = configuration.Services.GetApiExplorer().ApiDescriptions
               .FirstOrDefault(c =>
                   c.ActionDescriptor.ControllerDescriptor.ControllerType == typeof(TController)
                   && c.ActionDescriptor.ControllerDescriptor.ControllerType.GetMethod(actionName) == method
                   && c.ActionDescriptor.ActionName == actionName
               );
            var route = apiDescription.Route;
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary(routeValues));
            var request = new System.Net.Http.HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpRouteDataKey] = routeData;
            var virtualPathData = route.GetVirtualPath(request, routeValues);
            var path = virtualPathData.VirtualPath;
            return path;
        }
        private static string getRootPath(UrlHelper urlHelper) {
            var request = urlHelper.RequestContext.HttpContext.Request;
            var scheme = request.Url.Scheme;
            var server = request.Headers["Host"] ?? string.Format("{0}:{1}", request.Url.Host, request.Url.Port);
            var host = string.Format("{0}://{1}", scheme, server);
            var root = host + ToAbsolute("~");
            return root;
        }
        static string ToAbsolute(string virtualPath) {
            return VirtualPathUtility.ToAbsolute(virtualPath);
        }
    }
