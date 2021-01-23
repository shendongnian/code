    protected void Page_Init(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            // user is not logged in
            string ReturnUrl = HttpContext.Current.Request.Url.PathAndQuery;
            string RedirectUrl = "/Login.aspx";
            if (!String.IsNullOrEmpty(ReturnUrl))
            {
                RedirectUrl += "?ReturnUrl=" + Server.UrlEncode(ReturnUrl);
            }
            Response.Redirect(RedirectUrl);
        }
    }
