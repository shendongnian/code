	public class DispatcherExceptionHandler : IDispatchMessageInspector
	{
		public object AfterReceiveRequest(
			ref Message request, 
			IClientChannel channel, 
			InstanceContext instanceContext) => null;
		public void BeforeSendReply(ref Message reply, object correlationState)
		{
			try
			{
				reply.ToString();
			}
			catch (Exception e)
			{
				var faultCode = FaultCode.CreateSenderFaultCode(null);
				var faultReason = new FaultReason(e.GetBaseException().Message);
				reply = Message.CreateMessage(
					reply.Version,
					MessageFault.CreateFault(faultCode, faultReason),
					null);
			}
		}
	}
