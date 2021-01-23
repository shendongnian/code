    async Task<HttpResponseMessage> IActionFilter.ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
    {
        // Process the request pipeline and get the response (this causes the action to be executed)
        HttpResponseMessage response = await continuation();
        // Here you get access to:
        // - The request (actionContext.Request)
        // - The response (response) and its cookies (response.Headers.AddCookies())
        // - The principal (actionContext.ControllerContext.RequestContext.Principal)
        return response;
    }
