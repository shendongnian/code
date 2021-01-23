    public class ObservableDirectRouteProvider : IDirectRouteProvider
    {
        public IReadOnlyList<RouteEntry> DirectRoutes { get; private set; }
        public IReadOnlyList<RouteEntry> GetDirectRoutes(HttpControllerDescriptor controllerDescriptor, IReadOnlyList<HttpActionDescriptor> actionDescriptors, IInlineConstraintResolver constraintResolver)
        {
            var realDirectRouteProvider = new DefaultDirectRouteProvider();
            var directRoutes = realDirectRouteProvider.GetDirectRoutes(controllerDescriptor, actionDescriptors, constraintResolver);
            // Store the routes in a property so that they can be retrieved later
            DirectRoutes = directRoutes;
            return directRoutes;
        }
    }
