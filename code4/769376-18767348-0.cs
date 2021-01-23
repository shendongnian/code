    public class LogSoapMessageInterceptor : IDispatchMessageInspector
	{
		public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
		{
			MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
			request = buffer.CreateMessage(); //this step is important http://goo.gl/u4eBT
			Message message = buffer.CreateMessage(); //this step is important http://goo.gl/u4eBT
			StringBuilder sb = new StringBuilder();
			using (XmlWriter xw = XmlWriter.Create(sb))
			{
				message.WriteMessage(xw);
				xw.Close();
			}
			Logger.Log(String.Format("Received SOAP Request:\n{0}", sb.ToString()));
			
			return null;
		}
		public void BeforeSendReply(ref Message reply, object correlationState)
		{
			MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
			reply = buffer.CreateMessage();
			Logger.Log(String.Format("Sending SOAP Reply:\n{0}", buffer.CreateMessage().ToString()));
		}
    }
    public abstract class AbstractInterceptionBehavior<T> : IEndpointBehavior where T : IDispatchMessageInspector, new()
	{
		public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
		{
		}
		public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
		{
		}
		public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
		{
			T inspector = new T();
			endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
		}
		public void Validate(ServiceEndpoint endpoint)
		{
		}
	}
    public class LogSoapMessageBehavior : AbstractInterceptionBehavior<LogSoapMessageInterceptor>
	{
	}
    public class LogSoapMessageBehaviorExtensionElement : AbstractInterceptionBehaviorExtentionElement<LogSoapMessageBehavior>
	{
	}
    //related configuration settings
    <extensions>
      <behaviorExtensions>
        <add name="logSoapMessageBehavior"
             type="xyz.com.Web.Interceptors.LogSoapMessageBehaviorExtensionElement, xyz.com" />
      </behaviorExtensions>
    </extensions>
