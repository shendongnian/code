    public static MvcHtmlString ActionLinkButton(this HtmlHelper htmlHelper, string buttonText, string actionName, string controllerName, object routeValuesObject = null, object htmlAttributes = null)
    {
        // For testing - create links instead of buttons
        //return System.Web.Mvc.Html.LinkExtensions.ActionLink(htmlHelper, buttonText, actionName, controllerName, routeValues, htmlAttributes);
        if (string.IsNullOrEmpty(controllerName))
        {
            controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
        }
        RouteValueDictionary routeValuesDictionary = new RouteValueDictionary(routeValuesObject);
        RouteValueDictionary htmlAttr = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        TagBuilder tb = new TagBuilder("input");
        tb.MergeAttributes(htmlAttr, false);
        string href = UrlHelper.GenerateUrl("default", actionName, controllerName, routeValuesDictionary, RouteTable.Routes, htmlHelper.ViewContext.RequestContext, false);
        
        tb.MergeAttribute("type", "button");
        tb.MergeAttribute("value", buttonText);
        if (!tb.Attributes.ContainsKey("onclick"))
        {
            tb.MergeAttribute("onclick", "location.href=\'" + href + "\';return false;");
        }
        return new MvcHtmlString(tb.ToString(TagRenderMode.Normal).Replace("&#39;", "\'").Replace("&#32;"," "));
    }
