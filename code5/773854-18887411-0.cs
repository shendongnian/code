    var client = new MyServiceSoapClient();
    using (var scope = new OperationContextScope(client.InnerChannel))
    {
        // Create a custom soap header
        var msgHeader = MessageHeader.CreateHeader("myCustomHeader", "The_namespace_URI_of_the_header_XML_element", "myValue");
        // Add the header into request message
        OperationContext.Current.OutgoingMessageHeaders.Add(msgHeader);
    
        var res = await client.MyMethod();
    }
