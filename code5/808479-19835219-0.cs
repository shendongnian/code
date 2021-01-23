    public class ReadControllerActionInvoker : ControllerActionInvoker
    {
        private IMediator mediator;
        public ReadControllerActionInvoker(IMediator mediator)
        {
            this.mediator = mediator;
        }
        protected override ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            // this is where the magic happens...
            ViewDataDictionary model = null;
            // actionReturnValue is the result of our action which in our case will be a query
            // (see controller action below to see why)
            // we then simply pass this query to our mediator as we did in the controller
            if (actionReturnValue is DetailsQuery)
                model = new ViewDataDictionary(this.mediator.Request((DetailsQuery)actionReturnValue));
            // always return a View result with the returned model (equivalent of `return View(model)`)
            return new ViewResult
            {
                ViewName = actionDescriptor.ActionName,
                ViewData = model
            };
        }
    }
