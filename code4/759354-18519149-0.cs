    RuntimeHelpers.PrepareConstrainedRegions();
    try
    {
       // Aborts are delayed here.
       Thread.Sleep(1000); // ThreadAbortException can be injected here.
       // Aborts are delayed here.
    }
    finally
    {
        // CER code goes here.
    }
