    private static ManualResetEventSlim _event = new ManualResetEventSlim (false);
    public static void AwaitTemplatePropagation(this Connection conn, DBObject template)
    {
        template.PropertyUpdated += OnPropertyUpdated; // Something?
        template.RegisterForPropertyUpdates(new string[] { "TransactionCount" });
        // Magic happens?
        // if you are using this method many times you have to reset the event first
        _event.Reset(); //Sets the state of the event to nonsignaled, which causes threads to block.
        _event.WaitHandle.WaitOne();
        template.UnregisterPropertyUpdates(new string[] { "TransactionCount" });
        // Return to the calling function in the main thread
     }
    public void OnPropertyUpdated(...)
    {
        _event.Set();
    }
