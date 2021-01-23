    public class CustomDirectRouteProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyCollection<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
        }
    }
