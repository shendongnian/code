		public class MyMessageInspector : IDispatchMessageInspector
		{
			public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
			{
				var result = TryGetHeader(request, "name");
				return null;
			}
			public void BeforeSendReply(ref Message reply, object correlationState)
			{
			}
			 
			private String TryGetHeader(Message request, String headerName)
			{
				if (request.Headers.FindHeader(headerName, "MessageNamespace") != -1)
					return request.Headers.GetHeader<String>(headerName, "MessageNamespace");
				return null;
			}
		}
