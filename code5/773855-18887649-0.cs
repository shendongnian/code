    var client = new MyServiceSoapClient();
    using (new OperationContextScope(InnerChannel))
    { 
        WebOperationContext.Current.OutgoingRequest.Headers.Add(HttpRequestHeader.Authorization, "something");                
    }
