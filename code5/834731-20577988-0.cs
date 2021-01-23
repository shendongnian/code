    public static class HtmlHelperExtensions
    {
        private static string defaultImage = "/Content/uploads/virtual-data-center.png";
        public static string ImageOrDefault(this UrlHelper urlHelper, string fileName)
        {
            var imagePath = urlHelper.Content("/Content/uploads/") + fileName + ".png";
            HttpContextBase httpContext = urlHelper.RequestContext.HttpContext;
            var imageSrc = File.Exists(httpContext.Server.MapPath(imagePath))
                               ? imagePath : defaultImage;
            return imageSrc;
        }
    }
