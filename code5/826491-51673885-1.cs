    IDictionary<string,object> p = new ExpandoObject();
    // Add the values I want in the route
    foreach (var (key, value) in linkAttribute.ParamMap)
    {
        var v = GetPropertyValue(origin, value);                    
        p.Add(key, v); 
    }
    // Ideas borrowed from https://stackoverflow.com/questions/20349681/urlhelper-action-includes-undesired-additional-parameters
    // Null out values that I don't want, but are already in the RouteData
    foreach (var key in _urlHelper.ActionContext.RouteData.Values.Keys)
    {
        if (p.ContainsKey(key))
            continue;
                    
        p.Add(key, null); 
    }
    var href = _urlHelper.Action("Get", linkAttribute.HRefControllerName, p);
