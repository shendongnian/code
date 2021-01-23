    public ActionResult Run(string controllerName, string actionName)
    {
        // get the controller
        var ctrlFactory = ControllerBuilder.Current.GetControllerFactory();
        var ctrl = ctrlFactory.CreateController(this.Request.RequestContext, controllerName) as Controller;
        var ctrlContext = new ControllerContext(this.Request.RequestContext, ctrl);
        var ctrlDesc = new ReflectedControllerDescriptor(ctrl.GetType());
        // get the action
        var actionDesc = ctrlDesc.FindAction(ctrlContext, actionName);
        // execute
        var result = actionDesc.Execute(ctrlContext, new Dictionary<string, object>
        {
            { "parameterName", "TestParameter" }
        }) as ActionResult;
        // return the other action result as the current action result
        return result;
    }
