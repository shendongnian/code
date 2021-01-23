    public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
    {
        var header = request.Headers.GetHeader<MyHeader>("MyHeader", "replace this with you custom namespace uri");
    
        var userId = header.UserUID;
                
        // ...
        // ...
        // ...
    
        return null; 
    }
