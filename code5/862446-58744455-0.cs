    public override async Task OnActionExecutedAsync(HttpActionExecutedContext context, CancellationToken cancellationToken) {
                    var requestLog = context.Request;
                    if (requestLog != null)
                    {
                        _logger.DebugFormat("Request: {0}", requestLog?.ToString());
                        var requestBody = context.ActionContext?.ActionArguments;
                        if (requestBody != null)
                        {
                            _logger.DebugFormat("Body: {0}", JsonConvert.SerializeObject(requestBody));
                        }
                    }                   
        }
