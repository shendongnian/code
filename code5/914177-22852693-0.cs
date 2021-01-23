    private static ManualResetEventSlim _event = new ManualResetEventSlim (false);
    public static void AwaitTemplatePropagation(this Connection conn, DBObject template)
    {
        template.PropertyUpdated += OnPropertyUpdated; // Something?
        template.RegisterForPropertyUpdates(new string[] { "TransactionCount" });
        // Magic happens?
        _event.WaitHandle.WaitOne();
        template.UnregisterPropertyUpdates(new string[] { "TransactionCount" });
        // Return to the calling function in the main thread
     }
    public void OnPropertyUpdated(...)
    {
        _event.Set();
    }
