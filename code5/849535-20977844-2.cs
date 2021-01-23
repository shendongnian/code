    try
    {
        await previous();
    }
    catch(Exception ex)
    {
        exception = ex;
    }
    
    var context = new HttpActionExecutedContext(actionContext, exception);
    this.OnActionExecuted(context);
    if (context.Response == null && context.Exception != null)
        throw context.Exception;
