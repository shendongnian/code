    public static class NavigationHelper
    {
        public static MvcHtmlString BuildNavigation(this HtmlHelper htmlHelper, IEnumerable<NavigationItem> navigationItems)
        {
            var container = new TagBuilder("ul");
            container.MergeAttribute("id", "menu");
            var innerHtmlBuilder = new StringBuilder();
            foreach (var item in navigationItems.Where(item => IsAuthorized(htmlHelper, item.RouteValueDictionary)))
            {
                innerHtmlBuilder.Append(
                    new TagBuilder("li")
                    {
                        InnerHtml = htmlHelper.ActionLink(
                            item.LinkText, 
                            item.RouteValueDictionary["action"] as string,
                            item.RouteValueDictionary["controller"] as string, 
                            item.RouteValueDictionary, null).ToHtmlString()
                    });
            }
            container.InnerHtml = innerHtmlBuilder.ToString();
            return new MvcHtmlString(container.ToString());
        }
        private static bool IsAuthorized(this HtmlHelper htmlHelper, RouteValueDictionary routeValues)
        {
            var routeData = BuildRouteData(htmlHelper.RouteCollection, routeValues);
            var context = BuildRequestContext(htmlHelper, routeData);
            return ClaimsAuthorizationHelper.CheckAccess(context);
        }
        private static RouteData BuildRouteData(IEnumerable<RouteBase> routeCollection, RouteValueDictionary routeValues)
        {
            object controllerValue;
            routeValues.TryGetValue("controller", out controllerValue);
            var controllerName = controllerValue as string;
            object actionValue;
            routeValues.TryGetValue("action", out actionValue);
            var actionName = actionValue as String;
            object areaValue;
            routeValues.TryGetValue("area", out areaValue);
            var areaName = areaValue as String ?? "";
            var routeData = new RouteData();
            routeData.Values.Add("action", actionName);
            routeData.Values.Add("controller", controllerName);
            routeData.Values.Add("area", areaName);
            AddNamespaceInfo(routeData, routeCollection, areaName, controllerName, actionName);
            return routeData;
        }
        private static RequestContext BuildRequestContext(this HtmlHelper htmlHelper, RouteData routeData)
        {
            var claimsPrincipal = htmlHelper.ViewContext.HttpContext.User as ClaimsPrincipal;
            var requestContext = new RequestContext(htmlHelper.ViewContext.HttpContext, routeData);
            requestContext.HttpContext.User = claimsPrincipal;
            return requestContext;
        }
        private static void AddNamespaceInfo(RouteData routeData, IEnumerable<RouteBase> routeCollection, string areaName, string controllerName, string actionName)
        {
            var route = routeCollection.GetRoute(areaName, controllerName, actionName);
            if (route != null)
            {
                routeData.DataTokens.Add("Namespaces", route.DataTokens["Namespaces"]);
            }
        }
    }
