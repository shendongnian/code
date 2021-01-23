    public static string NonContextualAction(this UrlHelper helper, string action)
    {
        return helper.NonContextualAction(action,
            helper.RequestContext.RouteData.Values["controller"].ToString());
    }
    public static string NonContextualAction(this UrlHelper helper, string action,
                                             string controller)
    {
        var routeValues = helper.RequestContext.RouteData.Values;
        var routeValueKeys = routeValues.Keys.Where(o => o != "controller"
                             && o != "action").ToList();
        // Temporarily remove routevalues
        var oldRouteValues = new Dictionary<string, object>();
        foreach (var key in routeValueKeys)
        {
            oldRouteValues[key] = routeValues[key];
            routeValues.Remove(key);
        }
        // Get static page content
        string url = helper.Action(routeValues["Action"].ToString(),
                                   routeValues["Controller"].ToString());
        // Reinsert routevalues
        foreach (var kvp in oldRouteValues)
        {
            routeValues.Add(kvp.Key, kvp.Value);
        }
        return url;
    }
