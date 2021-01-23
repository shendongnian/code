    protected override ActionResult EndInvokeActionMethod(IAsyncResult asyncResult)
    {
        var actionResult = base.EndInvokeActionMethod(asyncResult);
        if(actionResult is JsonResult)
        {
            return new JsonNetResult(actionResult as JsonResult);
        }
        return actionResult;
    }
