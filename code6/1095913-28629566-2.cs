    public Task<HttpResponseMessage> ExecuteActionFilterAsync(
        HttpActionContext context,
        CancellationToken cancellationToken,
        Func<Task<HttpResponseMessage>> continuation)
    {
        if(!actionContext.ModelState.IsValid)
        {
            return Task.FromResult(actionContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, 
                actionContext.ModelState);
        }
        return continuation();
    }
