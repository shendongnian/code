    public static MvcHtmlString MenuItem(this HtmlHelper htmlHelper, string text, string action, string controller, string className )
    {
      StringBuilder html = new StringBuilder();
      TagBuilder i = new TagBuilder("i");
      i.AddCssClass("className");
      StringBuilder html = new StringBuilder();
      html.Append(i.ToString());
      TagBuilder span = new TagBuilder("span");
      span.InnerHtml = text;
      span.AddCssClass("title");
      html.Append(span.ToString());
      UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
      string href = urlHelper.Action(action, controller);
      TagBuilder a = new TagBuilder("a");
      a.MergeAttribute("href", href);
      a.InnerHtml = html.ToString();
      TagBuilder li = new TagBuilder("li");
      li.InnerHtml = a.ToString();
      return MvcHtmlString.Create(li.ToString());
    }
