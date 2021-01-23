    public static Boolean DEBUG(this System.Web.Mvc.WebViewPage page) {
    // use this sequence of returns to make the snippet ReSharper friendly. 
    #if DEBUG
            return true;
    #else
            return false;
    #endif
    }
