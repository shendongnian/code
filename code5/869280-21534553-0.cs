    protected void Application_BeginRequest(object sender, EventArgs ev)
    {
        string address = Request.Url.AbsoluteUri;
        if (address.Contains("www"))
        {
            Response.Redirect("site.com");
        }
    }
