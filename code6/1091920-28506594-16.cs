		public class MyMessageInspector : IDispatchMessageInspector
		{
			public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
			{
				var result = TryGetHeader(request, "name");
				return null;
			}
			[...]
		}
