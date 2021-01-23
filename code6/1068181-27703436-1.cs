    public HttpResponseMessage AAA()
    {
        var ctrlDesc = new HttpControllerDescriptor(this.Configuration, "UsersController", typeof(UsersController));
        var actionDesc = new ReflectedHttpActionDescriptor(ctrlDesc, typeof(UsersController).GetMethod("Test2"));
        var ctrlCtx = new HttpControllerContext(this.Configuration, this.Request.GetRouteData(), this.Request);
        var apiCtrl = ctrlDesc.CreateController(this.Request) as ApiController;
        apiCtrl.Request = this.Request;
        apiCtrl.Configuration = this.Configuration;
        apiCtrl.ControllerContext = ctrlCtx;
        ctrlCtx.Controller = apiCtrl;
        ctrlCtx.ControllerDescriptor = ctrlDesc;
        ctrlCtx.Request = this.Request;
        ctrlCtx.RouteData = this.Request.GetRouteData();
        var actionContext = new HttpActionContext(ctrlCtx, actionDesc);
        actionContext.ActionArguments.Add("ggg", "royi");
        var invoker = this.Configuration.Services.GetActionInvoker();
        return invoker.InvokeActionAsync(actionContext, CancellationToken.None).Result;
    }
