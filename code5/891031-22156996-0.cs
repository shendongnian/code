    public static Boolean DEBUG(this System.Web.Mvc.WebViewPage page) {
        var value = false;
    #if(DEBUG)
        value=true;
    #endif
        return value;
    }
