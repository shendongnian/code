    if (filterContext.HttpContext.Request.Cookies["ASP.NET_SessionId"] != null)
    {
        filterContext.HttpContext.Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);
    }
    filterContext.HttpContext.Session.Abandon();
