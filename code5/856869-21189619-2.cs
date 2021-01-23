    public static MvcHtmlString NoFollowActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues = null, object htmlAttributes = null)
    {
        var htmlAttributesDictionary = new Dictionary<string, object>();
        if (htmlAttributes != null)
        {
            foreach (var prop in htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                htmlAttributesDictionary.Add(prop.Name, prop.GetValue(htmlAttributes, null));
            }
        }
        htmlAttributesDictionary["rel"] = "nofollow";
        var routeValuesDictionary = new RouteValueDictionary(routeValues);
        var link = htmlHelper.ActionLink(linkText, actionName, controllerName, routeValuesDictionary, htmlAttributesDictionary);
        return link;
    }
