    public HttpResponseMessage AAA()
    {
        var invoker = this.Configuration.Services.GetActionInvoker();
        var actionDesc = new ReflectedHttpActionDescriptor(
                                    this.ControllerContext.ControllerDescriptor,
                                    typeof(UsersController).GetMethod("Test2"));
        var actionContext = new HttpActionContext(this.ControllerContext, actionDesc);
        actionContext.ActionArguments.Add("ggg", "royi");
        return invoker.InvokeActionAsync(actionContext, CancellationToken.None).Result;
    }
