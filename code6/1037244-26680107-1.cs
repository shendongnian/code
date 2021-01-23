    internal static void ActionHelper(HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, TextWriter textWriter)
    {
        ...
        //The route values provided to @Html.Action are merged with the current ones
        RouteValueDictionary additionalRouteValues = routeValues;
        routeValues = MergeDictionaries(routeValues, htmlHelper.ViewContext.RouteData.Values);
        ...
    }
