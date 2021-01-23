    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if(HttpContext.Request.Cookies["sid"] == null
            && HttpContext.Response.Cookies["sid"] == null) {
            HttpCookie htsid = new HttpCookie("sid", Guid.NewGuid().ToString());
            HttpContext.Response.Cookies.Set(htsid);
        }
        //...
    }
