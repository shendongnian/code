    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        if (actionExecutedContext.Exception == null)
            return;
        WriteLog(actionExecutedContext.Exception);
        actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(
            System.Net.HttpStatusCode.InternalServerError,
            actionExecutedContext.Exception.Message,
            actionExecutedContext.Exception);
        actionExecutedContext.Exception = null;
    }
