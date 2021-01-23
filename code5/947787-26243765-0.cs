    public static class HtmlExtensions
    {
        public static string GetPreloadGlyphUrl(this HtmlHelper htmlHelper)
        {
            return Properties.Settings.Default.PreloadGlyphUrl;
        }
    }
