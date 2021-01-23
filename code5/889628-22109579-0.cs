    protected override void OnActionExecuting(ActionExecutingContext ctx) {
        base.OnActionExecuting(ctx);
        ctx.HttpContext.Trace.Write("Log: OnActionExecuting",
             "Calling " +
             ctx.ActionDescriptor.ActionName);
    }
