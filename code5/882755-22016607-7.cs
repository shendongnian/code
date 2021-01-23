    public static string Resource(this HtmlHelper helper, string resourceName, string resourceKey)
    {
        return helper.ViewContext.HttpContext.GetGlobalResourceObject(resourceName, resourceKey).ToString();
    }
    public static string Resource(this WebViewPage page, string resourceKey)
    {
        return page.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, resourceKey).ToString();
    }
