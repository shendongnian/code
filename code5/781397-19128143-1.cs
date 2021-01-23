    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GetContentPath(this HtmlHelper htmlHelper, string relativeContentPath)
        {
            EnsureContentServerPath();
            return new MvcHtmlString(string.Format("{0}/{1}", ContentServerPath, relativeContentPath));
        }
        public static string ContentServerPath;
        private static void EnsureContentServerPath()
        {
            if(EnsureContentServerPath == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
