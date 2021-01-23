    public class ContainerActionInvoker : ApiControllerActionInvoker
    {
        private readonly Container container;
        public ContainerActionInvoker(Container container)
        {
            this.container = container;
        }
        public override Task<HttpResponseMessage> InvokeActionAsync(
            HttpActionContext actionContext, 
            CancellationToken cancellationToken)
        {
            if (actionContext.ControllerContext.Controller is MyHttpControllerDecorator)
            {
                MyHttpControllerDecorator decorator =
                    (MyHttpControllerDecorator)actionContext.ControllerContext.Controller;
                // decoratee changed to public for the example
                actionContext.ControllerContext.Controller = decorator.decoratee;
            }
            var result = base.InvokeActionAsync(actionContext, cancellationToken);
            return result;
        }
    }
