    var currentUrl = Request.Url.AbsolutePath;
    if (Page.RouteData != null)
    {
        if (Page.RouteData.Route!=null)
        {
            var virtualPathData = Page.RouteData.Route.GetVirtualPath(Request.RequestContext, Page.RouteData.Values);
            if (virtualPathData != null)
            {
                //asp.net routing
                currentUrl = virtualPathData.VirtualPath;
            }
            else
            {
                //only for Microsoft.AspNet.FriendlyUrls
                //GetFriendlyUrlFileVirtualPath never returns nulls
                currentUrl = Request.GetFriendlyUrlFileVirtualPath().Replace("~", "");
            }
        }
    }
