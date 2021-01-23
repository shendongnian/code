    public class CreatePublishedContentRequestAttribute
        : EnsurePublishedContentRequestAttribute
    {
        public CreatePublishedContentRequestAttribute() : base(0) { }
        protected override void ConfigurePublishedContentRequest(
            PublishedContentRequest publishedContentRequest,
            ActionExecutedContext filterContext)
        {
            var contentId = filterContext.RouteData.Values["id"];
            int id = 0;
            if (contentId != null && int.TryParse(contentId.ToString(), out id))
            {
                var content = UmbracoContext.ContentCache.GetById(id);
                publishedContentRequest.PublishedContent = content;
                var defaultLanguage = Language.GetAllAsList().FirstOrDefault();
                publishedContentRequest.Culture = (defaultLanguage == null)
                    ? CultureInfo.CurrentUICulture
                    : new CultureInfo(defaultLanguage.CultureAlias);
                publishedContentRequest.ConfigureRequest();
                HttpContext.Current.Session["PublishedContentRequest"]
                    = publishedContentRequest;
            }
        }
    }
