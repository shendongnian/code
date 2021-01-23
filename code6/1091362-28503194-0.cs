        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                    .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                    .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");
            });
            pipelines.OnError.AddItemToEndOfPipeline((ctx, exc) =>
            {
                if (exc != null)
                {
                    throw exc;
                }
                return HttpStatusCode.InternalServerError;
            });
            base.RequestStartup(container, pipelines, context);
        }
