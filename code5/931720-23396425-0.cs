    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CustomActionLink(this HtmlHelper Helper, string LinkText, string ActionName)
        {
            string link = getCustomName();
            if(!String.IsNullOrWhiteSpace(link))
            {
                return link
            }
            return helper.ActionLink(LinkText, ActionName);
        }
    }
