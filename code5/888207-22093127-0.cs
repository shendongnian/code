    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
            {
                
    
                pipelines.AfterRequest += ctx =>
                {
                    ctx.Response.WithHeader("Access-Control-Allow-Origin", "*");
                    ctx.Response.WithHeader("Access-Control-Allow-Headers", "accept, client-token, content-type");
                    ctx.Response.WithHeader("Access-Control-Allow-Methods", "POST, GET");
                    ctx.Response.WithHeader("Access-Control-Max-Age", "30758400");
                };
            }
