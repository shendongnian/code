    public class FixedAsyncRenderControllerFactory : RenderControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controller1 = base.CreateController(requestContext, controllerName);
            var controller2 = controller1 as Controller;
            if (controller2 != null)
                controller2.ActionInvoker = new FixedAsyncRenderActionInvoker();
            return controller1;
        }
    }
