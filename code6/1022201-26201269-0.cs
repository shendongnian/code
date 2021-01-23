    WebOperationContext webOperationContext = WebOperationContext.Current;
    if (webOperationContext != null)
    {
        webOperationContext.OutgoingResponse.Headers.Add("X-Version", "1");
    }
