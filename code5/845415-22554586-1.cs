    var currentSynchronizationContext = SynchronizationContext.Current;
    try
    {
        SynchronizationContext.SetSynchronizationContext(new OperationContextSynchronizationContext(client.InnerChannel));
        var response = await client.RequestAsync();
        // safe to use OperationContext.Current here
    }
    finally
    {
        SynchronizationContext.SetSynchronizationContext(currentSynchronizationContext);
    }
