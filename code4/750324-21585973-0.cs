    var routeValues = HttpContext.Current.Request.RequestContext.RouteData.Values;
    if (routeValues != null) 
    {
        if (routeValues.ContainsKey("action"))
        {
            var actionName = routeValues["action"].ToString();
                    }
        if (routeValues.ContainsKey("controller"))
        {
            var controllerName = routeValues["controller"].ToString();
        }
    }
