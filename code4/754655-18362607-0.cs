    using Sysem.Web.Mvc;
    using Sysem.Web.Mvc.Html;
    public static class PartialHelper
    {
        public static void RenderMostRecent(this HtmlHelper html)
        {
            html.RenderAction("MostPopular", "Blog");
        }
    }
