    namespace MyApplication.Helpers
    {
      public static class CustomHtmlHelepers
      {
        public static IHtmlString ActionLinkWithSpan(this HtmlHelper htmlHelper, string linkText, string action, string controller, object routeValues, object htmlAttributes)
        {
           var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
           var span = new TagBuilder("span") { InnerHtml = linkText };
           var anchor = new TagBuilder("a") { InnerHtml = span.ToString() };
           anchor.Attributes["href"] = urlHelper.Action(action, controller, routeValues);
           anchor.MergeAttributes(new RouteValueDictionary(htmlAttributes));
                
           return MvcHtmlString.Create(anchor.ToString());
    
        }
      }
    }
