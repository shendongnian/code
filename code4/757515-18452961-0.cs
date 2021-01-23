    public static string Absolute(this UrlHelper url, string relativeUrl)
    {
        var request = url.RequestContext.HttpContext.Request;
        return string.Format("{0}://{1}{2}",
            (request.IsSecureConnection) ? "https" : "http",
            request.Headers["Host"],
            VirtualPathUtility.ToAbsolute(relativeUrl));
    }
