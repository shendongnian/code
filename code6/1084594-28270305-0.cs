    protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
    {
        base.RequestStartup(container, pipelines, context);
    
        pipelines.AfterRequest.AddItemToEndOfPipeline(c =>
        {
            c.Response.Headers["x-fcr-version"] = "1";
        });
    }
