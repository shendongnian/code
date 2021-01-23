    private static bool IsWcfTracingEnabled()
    {
        TraceSource ts = new TraceSource("System.ServiceModel.MessageLogging");
        return ts.Listeners.Count > 0;
    }
