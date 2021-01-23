        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var factory = this.GetFactory(requestContext);
            var controller = factory.CreateController(requestContext, controllerName);
            // By storing the factory in the request items for this controller, 
            // we allow it to be easily retrieved
            // during ReleaseController and delegate releasing to the correct controller.
            HttpContext.Current.Items["ContrFct_" + controller.GetType().FullName] = factory;
            return controller;
        }
        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext,
            string controllerName)
        {
            var factory = this.GetFactory(requestContext);
            return factory.GetControllerSessionBehavior(requestContext, controllerName);
        }
        public void ReleaseController(IController controller)
        {
            var controllerFactory = (IControllerFactory)HttpContext.Current.Items["ContrFct_" +
                controller.GetType().FullName];
            controllerFactory.ReleaseController(controller);
        }
        private IControllerFactory GetFactory(RequestContext context)
        {
            // return the module specific factory based on the requestcontext
        }
    }
