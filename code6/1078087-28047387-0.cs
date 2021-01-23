    private void onUpdateRequestCache(object sender, EventArgs e)
    {
        var application = (HttpApplication)sender;
        application.Context.Response.Cache.SetCacheability(HttpCacheability.Public); //Location="Any"
        application.Context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(1800)); //Duration="1800"
        application.Context.Response.Cache.SetValidUntilExpires(true);
    }
