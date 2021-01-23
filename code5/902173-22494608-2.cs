    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var mainSiteUrl = _mobileToMainRedirect.GetMainSiteUrl(filterContext.HttpContext.Request.Url);
        filterContext.Controller.ViewData.Add(AppConstants.MainSiteUrl, string.IsNullOrEmpty(mainSiteUrl) ? UrlHelperExtensions.FullBrowserSite(filterContext.HttpContext.Request.Url) : mainSiteUrl);
    }
