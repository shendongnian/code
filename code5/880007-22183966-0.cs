    public class FilteredControllerFactory : ControllerFactory, IFilteredControllerFactory
    {
        public bool CanHandle(RequestContext request)
        {
            Type controllerType = GetControllerType(request, request.RouteData.Values["controller"].ToString());
            return ApplicationStartup.Container.Kernel.HasComponent(controllerType);
        }
    }
