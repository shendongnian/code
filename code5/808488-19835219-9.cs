    public class ReadControllerActionInvoker : ControllerActionInvoker
    {
        private IMediator mediator;
        public ReadControllerActionInvoker(IMediator mediator)
        {
            this.mediator = mediator;
        }
        protected override ActionResult CreateActionResult(ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            ViewDataDictionary model = null;
            
            // get our query parameter
            var query = GetParameterValue(controllerContext, actionDescriptor.GetParameters().Where(x => x.ParameterName == "query").FirstOrDefault());
            
            // pass the query to our mediator
            if (query is DetailsQuery)
                model = new ViewDataDictionary(this.mediator.Request((DetailsQuery)query));
            // return the view with read model returned from mediator
            return new ViewResult
            {
                ViewName = actionDescriptor.ActionName,
                ViewData = model
            };
        }
    }
