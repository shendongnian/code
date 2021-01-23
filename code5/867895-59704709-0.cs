    class myFilter : ExceptionFilterAttribute
    {
    ...
        public override async Task OnExceptionAsync(HttpActionExecutedContext ctx, 
                                                    CancellationToken cancellationToken)
        {
        ...
        }
    ...
    }
