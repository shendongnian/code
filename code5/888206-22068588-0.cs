    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        pipelines.AfterRequest += ctx =>
        {
            // This will always be called at the end of the request
            if (ctx.Request.Method.Equals("OPTIONS", StringComparison.Ordinal))
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*");
                ctx.Response.WithHeader("Access-Control-Allow-Headers", "accept, client-token, content-type");
                ctx.Response.WithHeader("Access-Control-Allow-Methods", "POST, GET");
                ctx.Response.WithHeader("Access-Control-Max-Age", "30758400");
            }
        }
    }
