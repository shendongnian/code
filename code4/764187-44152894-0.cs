    public class LogUnhandledExceptionBehavior : IServiceBehavior
    {
       ...
       public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcher in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>())
            {
                // Don't add error handler on channelDispatcher with system endpoints, as they can throw spurious errors
                // and ones we cannot do anything about anyway.
                if (channelDispatcher.Endpoints.Any(dispatcher => dispatcher.IsSystemEndpoint))
                    continue;
                channelDispatcher.ErrorHandlers.Add(GenericErrorHandler.StaticInstance);
            }
        ...
        }
