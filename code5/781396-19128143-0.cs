    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GetContentPath(this HtmlHelper htmlHelper, string relativeContentPath)
        {
            EnsureWrapper();
            return new MvcHtmlString(string.Format("{0}/{1}", ConfigurationWrapper.ContentServerPath, relativeContentPath));
        }
        public static IConfigurationWrapper ConfigurationWrapper;
        private static void EnsureWrapper()
        {
            if(ConfigurationWrapper == null)
            {
                throw new InvalidOperationException();
            }
        }
    }
