    protected IHttpActionResult InvokeWithExceptionHandler(Func<IHttpActionResult> tryBlock)
    {
        try
        {
            return tryBlock();
        }
        catch (Exception ex)
        {
            // map exceptions to specific IHttpActionResult ... etc
            return HandleException(ex);
        }   
    }
