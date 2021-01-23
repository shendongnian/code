    using (OperationContextScope scope = new OperationContextScope((IContextChannel)channel))
    {
        MessageHeader<string> header = new MessageHeader<string>("secret message");
        var untyped = header.GetUntypedHeader("Identity", "http://www.my-website.com");
        OperationContext.Current.OutgoingMessageHeaders.Add(untyped);
    
        // now make the WCF call within this using block
    }
