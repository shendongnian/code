    protected void Application_BeginRequest(object sender, System.EventArgs e)
    {
        string file = Request.Url.LocalPath.ToLower();
        if (file == ("/user/singin"))
        {
            //something
        }
    }
