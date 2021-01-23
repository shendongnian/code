    namespace Tutorial.Examples
    {
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
     
    public static class HtmlExtensions
    {
    public static MvcHtmlString ActionLinkWithSpan(this HtmlHelper html,
    string linkText,
    string actionName,
    string controllerName,
    object htmlAttributes)
    {
    RouteValueDictionary attributes = new RouteValueDictionary(htmlAttributes);
    TagBuilder linkTag = new TagBuilder("a");
    TagBuilder spanTag = new TagBuilder("span");
    spanTag.SetInnerText(linkText);
     
    // Merge Attributes on the Tag you wish the htmlAttributes to be rendered on.
    // e.g. linkTag.MergeAttributes(attributes);
    spanTag.MergeAttributes(attributes);
     
    UrlHelper url = new UrlHelper(html.ViewContext.RequestContext);
    linkTag.Attributes.Add("href", url.Action(actionName, controllerName));
    linkTag.InnerHtml = spanTag.ToString(TagRenderMode.Normal);
    return MvcHtmlString.Create(linkTag.ToString(TagRenderMode.Normal));
    }
    }
    }
