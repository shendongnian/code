    public Response ConvertToHttpResponse(Exception exception, NancyContext context, IEnumerable<IResponseProcessor> processors, Nancy.Conventions.AcceptHeaderCoercionConventions coercionConventions)
    {
        var negotiator = new Negotiator(context)
            .WithStatusCode(HttpStatusCode.BadRequest)
            .WithReasonPhrase(exception.Message);
        return new DefaultResponseNegotiator(processors, coercionConventions)
            .NegotiateResponse(negotiator, context);
    }
