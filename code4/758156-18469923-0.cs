    public static class LinkExtensions
    {
        public static IHtmlString MyActionLink(
            this HtmlHelper html,
            string linkText,
            string actionName,
            string controllerName,
            IDictionary<string, string> parameters
        )
        {
            var a = new TagBuilder("a");
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var query = string.Join("&", parameters.Select((x, i) => string.Format("[{0}].Key={1}&[{0}].Value={2}", i, urlHelper.Encode(x.Key), urlHelper.Encode(x.Value))));
            var url = string.Format(
                "{0}?{1}",
                urlHelper.Action(actionName, controllerName, null, html.ViewContext.HttpContext.Request.Url.Scheme),
                query
            );
            a.Attributes["href"] = url;
            a.SetInnerText(linkText);
            return new HtmlString(a.ToString());
        }
    }
