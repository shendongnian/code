    public static MvcHtmlString NoFollowActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
    {
        var routeValuesDict = new RouteValueDictionary(routeValues);
        var customAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        if (!customAttributes.ContainsKey("rel"))
            customAttributes.Add("rel", "nofollow");
        return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValuesDict, customAttributes);
    }
