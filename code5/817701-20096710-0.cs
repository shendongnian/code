    public static class HtmlExtensions
    {
        public static IHtmlString ErrorMessage(this HtmlHelper html, string msg)
        {            
            return MvcHtmlString.Create("<span class=\"validation-summary-errors\">"+msg+"</span>");            
        }
    }
