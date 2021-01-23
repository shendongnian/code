    public void OnEndRequest(object sender, EventArgs e)
    {
        HttpApplication app = (HttpApplication) sender;
        HttpContext ctx = app.Context;
        DoCustomProcessing(ctx.Response);
    }
