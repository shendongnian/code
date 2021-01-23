    using (new OperationContextScope((IContextChannel)channel))
    {
    MessageHeader customMessageHeader = MessageHeader.CreateHeader(<name>, <namespace>, <value>);
    OperationContext.Current.OutgoingMessageHeaders.Add(customMessageHeader);
    }
