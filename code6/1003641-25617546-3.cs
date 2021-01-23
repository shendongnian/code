    public static class HtmlExtensions {
        private const string FDir_AppData = "~/App_Data/";
        
        public static MvcHtmlString File(this HtmlHelper helper, string name){
            return MvcHtmlString.Create(Path.Combine(FDir_AppData, name));
        }
    }
