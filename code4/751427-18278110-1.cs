    using (System.ServiceModel.OperationContextScope scope = new System.ServiceModel.OperationContextScope((IContextChannel)utz.InnerChannel))
    {
        MessageHeaders messageHeadersElement =  MessageHeader.CreateHeader("SOAPAction", String.Empty, "UTZ_EMP_BIO_INFO.v1");
        OperationContext.Current.OutgoingMessageHeaders.Add(messageHeadersElement);
    etc...
    
