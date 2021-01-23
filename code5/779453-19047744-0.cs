    var client = GetMyFactory("username", "password);
    using (operationContextScope = new OperationContextScope((IClientChannel)client))
    {
        OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);
        client.DoSomething()
        ....
    }
