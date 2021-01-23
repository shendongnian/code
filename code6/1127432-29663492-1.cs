    public static class JavascriptHelperEx
    {
    	public static IHtmlString QuotedJsString(this HtmlHelper htmlHelper, string str)
    	{
            //true parameter below wraps everything in double quotes:
    		return htmlHelper.Raw(HttpUtility.JavaScriptStringEncode(str, true));
    	}
    }
