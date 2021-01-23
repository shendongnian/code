    public class SOAPInspector : IClientMessageInspector {
    public void AfterReceiveReply(ref Message reply, object correlationState) {
      //Your code
    }
    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel) {
        //Your code
    }
    }
