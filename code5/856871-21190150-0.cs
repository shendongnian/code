    public static MvcHtmlString NoFollowActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
    {
        var customAttributes = new RouteValueDictionary(htmlAttributes) { { "rel", "nofollow" } };
        var routeValuesDict = new RouteValueDictionary(routeValues);
        return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValuesDict, customAttributes);
    }
