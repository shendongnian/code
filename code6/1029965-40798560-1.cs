    public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
           var owincontext = request.GetOwinContext().Environment;
           var headerParser= new HeaderParser(owincontext);
           var logger = _dpendencyManager.Resolve(typeof(IPOSLogger)) as IPOSLogger;
           var executionContext = new ExecutionContext(logger, owincontext,headerParser.GetEmployeeNoFromHeader());
           var controller =
               (IHttpController)_dpendencyManager.Resolve(controllerType, new { context = executionContext });
           //var controller =
           //  (IHttpController)_dpendencyManager.Resolve(controllerType);
           request.RegisterForDispose(
               new Release(
                   () => _dpendencyManager.Release(controller)));
            return controller;
        }
