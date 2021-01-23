    public static class DisposableExtensions
    {
        public static IDisposable SampleHelper(this HtmlHelper htmlHelper)
        {
            string startTag = @"<div class='content'>";
            string endTag = "</div>";
            return new DisposableHelper(
                () => htmlHelper.ViewContext.HttpContext.Response.Write(startTag),
                () => htmlHelper.ViewContext.HttpContext.Response.Write(endTag)
            );
        }
    }
