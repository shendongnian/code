    public static class MyHelpers()
    {
        public static MvcHtmlString MyAction(this UrlHelper url, string actionName)
        {
            // return whatever you want (here's an example)...
            return url.Action(actionName, new RouteValueDictionary());
        }
    }
