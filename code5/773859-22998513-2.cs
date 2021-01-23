    SoapServiceClient client = new SoapServiceClient();
    
    using(new OperationContextScope(client.InnerChannel)) 
    {
        // // Add a SOAP Header (Header property in the envelope) to an outgoing request. 
        // MessageHeader aMessageHeader = MessageHeader
        //    .CreateHeader("MySOAPHeader", "http://tempuri.org", "MySOAPHeaderValue");
        // OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);
    
        // Add a HTTP Header to an outgoing request
        HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
        requestMessage.Headers["MyHttpHeader"] = "MyHttpHeaderValue";
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] 
           = requestMessage;
    
    	var result = client.MyClientMethod();
    }
