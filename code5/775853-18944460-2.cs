    namespace System.Web.Mvc {
    {
        public static class HtmlHelperExtensions
        {
            public static MvcHtmlString CustomActionLink(this HtmlHelper htmlHelper, tring linkText, string actionName, string controllerName)
            {
                return new MvcHtmlString(String.Format("<a href='http://myUrl.com/{0}/{1}'>{2}</a>", controllerName, actionName, linkText));
            }
        }
    }
