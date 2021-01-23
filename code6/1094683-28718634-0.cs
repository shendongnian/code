    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {            
            var key = request.Headers.MessageId.ToString();
            
            //Do stuff
            
            return null;
    }
    public void AfterReceiveReply(ref Message reply, object correlationState)
    {            
            var key = reply.Headers.RelatesTo.ToString();            
            //Do stuff
    }
