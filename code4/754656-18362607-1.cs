    public static class PartialHelper
    {
        public static IHtmlString RenderMostRecent(this HtmlHelper html)
        {
            return html.Action("MostPopular", "Blog");
        }
    }
