    public class OutputMessageInspector : IDispatchMessageInspector
    {
       public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
       {
           // Parse request & read required information
           // Insert request data into log tables
           // Set lastLogId to the id created above
           return lastLogId
       }
    
       public void BeforeSendReply(ref Message reply, object correlationState)
       {
           // Parse reply
           int lastLogId = (int)correlationState;
       }
    }
