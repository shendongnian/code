    public class AuthenticationInterceptor : RequestInterceptor, IDispatchMessageInspector
    {
        //Authentication logic goes here......
        object IDispatchMessageInspector.AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
    	    //Your code here.
        }
        void IDispatchMessageInspector.BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
    	    //Your code here.
        }
    }
