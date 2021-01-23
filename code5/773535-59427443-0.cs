    protected RedirectResult RedirectToCurrentUri(String strQueryStringOverride = "")
    {
        String strReferrer = Request.UrlReferrer.AbsoluteUri;
        if (String.IsNullOrWhiteSpace(strReferrer))
        {
            strReferrer = "/";
        }
        // Can also override referrer here for instances where page has 
        // refreshed and replaced referrer with current url.
        if (!String.IsNullOrWhiteSpace(strQueryStringOverride))
        {
            String strPath = (strReferrer ?? "").Split('?', '#')[0];
            return Redirect(strPath + strQueryStringOverride);
        }
        return Redirect(strReferrer);
    }
