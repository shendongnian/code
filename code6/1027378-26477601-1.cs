    public class UnityControllerFactory : DefaultControllerFactory 
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller = null;
            var type = GetControllerType(requestContext, controllerName);
            if (type != null)
            {
                // read host from incoming url
                var domain = requestContext.HttpContext.Request.Url.Host.ToLower();
                // get parent unity container
                var container = DependencyResolver.Current.GetService<IUnityContainer>();
                // check if there is a child container for this domain
                if (container.IsRegistered<IUnityContainer>(domain))
                {
                    container = container.Resolve<IUnityContainer>(domain);
                }
                controller = container.Resolve(type) as IController;
            }
            // if didn't find type or not right type just pass into base to handle errors
            if (controller == null)
            {
               return base.CreateController(requestContext, controllerName);
            }
            return controller;
        }
    }
