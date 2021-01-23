    public void OnResultExecuting(ResultExecutingContext filterContext)
    {
        var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
       //That will give you "HomeController". You can remove the "Controller" part, by replacing it with an empty string, like:
       var controllerNameWithoutController = controllerName.Replace("Controller", string.Empty");
    }
