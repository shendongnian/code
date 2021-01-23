    public string GetData(int value)
    {
        var headers = OperationContext.Current.IncomingMessageHeaders;
        int headerIndex = headers.FindHeader("SessionID", string.Empty);
        ...
    }
