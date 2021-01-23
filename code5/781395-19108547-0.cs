    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GetContentPath(this HtmlHelper htmlHelper, string relativeContentPath)
        {
            return GetContentPath(relativeContentPath, AutofacDependencyResolver.Current.ApplicationContainer.Resolve<IConfigurationWrapper>());
        }
        internal static MvcHtmlString GetContentPath(string relativeContentPath, IConfigurationWrapper configuration)
        {
            return new MvcHtmlString(string.Format("{0}/{1}", configuration.ContentServerPath, relativeContentPath););
        }
    }
