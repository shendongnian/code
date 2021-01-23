    public static string ActionWithCurrentQuery(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues)
            {
                var request = urlHelper.RequestContext.HttpContext.Request;
                var url = urlHelper.Action(actionName, controllerName, routeValues, "http");
                var uriBuilder = new UriBuilder(url);
                var query = HttpUtility.ParseQueryString(string.Empty);
                foreach (string key in request.QueryString.Keys)
                {
                    query[key] = request[key];
                }
                var routeQuery = HttpUtility.ParseQueryString(uriBuilder.Query);
                foreach (string key in routeQuery)
                {
                    query[key] = routeQuery[key];
                }
                uriBuilder.Query = query.ToString();
    
                return uriBuilder.ToString();
            }
              
