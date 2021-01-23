    protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
    {
        //  Resolving outside the lambda because no more components will be registered at this point.
        var responseProcessors = container.Resolve<IEnumerable<Nancy.Responses.Negotiation.IResponseProcessor>>();
        var coercionConventions = container.Resolve<AcceptHeaderCoercionConventions>();
        pipelines.OnError += (context, exception) => 
        {
            return exception.GetErrorResponse(context, responseProcessors, coercionConventions);
        };
    }
