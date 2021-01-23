    public void Init(HttpApplication context)
    {
        context.PreRequestHandlerExecute += new EventHandler(this.RegisterPagePrerenderHandler);
    }
    
    private void RegisterPagePrerenderHandler(object s, EventArgs e)
    {
        if (HttpContext.Current.Handler is Page)
        {
            Page page = (Page) HttpContext.Current.Handler;
            page.PreRender += delegate (object ss, EventArgs ee) {
                if (page is CDefault)
                {
                    page.ClientScript.RegisterClientScriptInclude("key", page.ResolveUrl("~/myjs.js"));
                }
            };
        }
    }
