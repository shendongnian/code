    public override async Task OnExceptionAsync(HttpActionExecutedContext context, CancellationToken cancellationToken)
    {
        if (!cancellationToken.IsCancellationRequested)
        {
            //Handle domain specific exceptions here if any.
    
            //Handle all other Web Api (not all, but Web API specific only ) exceptions
            Logger.Write(context.Exception, "Email");
    
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An unhandled exception was thrown.");
        }
    }
