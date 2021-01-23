    public static class ViewUtility
    {
        private const string _areasRoot = "~/Areas/";
    
        public static string CurrentAreaRelativePath(string path)
        {
            var currentArea = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"];
    
            return VirtualPathUtility.Combine(_areasRoot, currentArea + "/" + path);
        }
    }
    @RenderPage(ViewUtility.CurrentAreaRelativePath("themes/MyTheme/Post.cshtml"), post);
