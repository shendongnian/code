    // UI thread
    var uiSynchronizationContext = System.Threading.SynchronizationContext.Current;
    if (uiSynchronizationContext == null)
        throw new NullReferenceException("SynchronizationContext.Current");
    ThreadPool.QueueUserWorkItem(x =>
    {
        // pool thread
        try
        {
            uiSynchronizationContext.Send(s => Test(), null);
        }
        catch (Exception ex)
        {
            Debug.Print(ex.ToString());
        }
    });
