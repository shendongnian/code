    public static class LanguageLiteralExtension
    {
        public static string LanguageLiteral(this HtmlHelper helper)
        {
            return helper.ViewContext.RequestContext.RouteData.Values["language"].ToString();
        }
    }
