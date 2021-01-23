    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        var p = Request.Path.ToLower().Trim();
        if (p.EndsWith("/crystalimagehandler.aspx") && p != "/crystalimagehandler.aspx")
        {
            var fullPath = Request.Url.AbsoluteUri.ToLower();
            var NewURL = fullPath.Replace(".aspx", "");
            Response.Redirect(NewURL);
        }
    }
