    public static class UrlHelperExtensions
    {
        public static MvcHtmlString Pdf(this UrlHelper helper, string fileName, string directory)
        {
            string _fileName = fileName + ".pdf";
            string _directory = directory + "/";
            string root = "~/Content/";
            string path = HttpContext.Current.Server.MapPath(root + _directory + _fileName);
            if (File.Exists(path))
            {
                return new MvcHtmlString("<a href=Downloadfile/" + _directory + fileName + " target=\"_blank\">Download Template</a>");
            }
            else
            {
                return new MvcHtmlString(string.Empty);
            }
        }
    }
