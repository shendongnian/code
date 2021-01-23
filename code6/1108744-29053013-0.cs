    public interface IDispatchMessageInspector
    {
        object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext);
        void BeforeSendReply(ref Message reply, object correlationState);
    }
     
    public interface IClientMessageInspector
    {
        void AfterReceiveReply(ref Message reply, object correlationState);
        object BeforeSendRequest(ref Message request, IClientChannel channel);
    }
