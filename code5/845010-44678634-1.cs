	public class HandleDispatcherExceptionsServiceBehavior : IServiceBehavior
	{
		public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
		{
			foreach (var dispatchRuntime in serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>().SelectMany(ch => ch.Endpoints).Select(epd => epd.DispatchRuntime))
				dispatchRuntime.MessageInspectors.Add(new DispatcherExceptionHandler());
		}
		
		// (...)
	}
