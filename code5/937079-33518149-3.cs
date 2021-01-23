    public void Configuration(IAppBuilder app)
    {
        RequireAspNetSession(app);
        app.Run(async context =>
        {
            if (context.Request.Uri.AbsolutePath.EndsWith("write"))
            {
                HttpContext.Current.Session["data"] = DateTime.Now.ToString();
                await context.Response.WriteAsync("Wrote to session state!");
            }
            else
            {
                var data = (HttpContext.Current.Session["data"] ?? "No data in session state yet.").ToString();
                await context.Response.WriteAsync(data);
            }
        });
    }
