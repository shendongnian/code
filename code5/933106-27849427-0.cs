    using (new OperationContextScope((IContextChannel)channel))
    {
          OperationContext.Current.OutgoingMessageProperties.Add("P1", "Test User");
          OperationContext.Current.OutgoingMessageProperties.Add("P2", "Test Type");
          response = client.process(request);
    }
