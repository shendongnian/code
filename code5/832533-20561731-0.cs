    new Thread(Run).Start(...);
    void Run(object args)
    {
        WindowsImpersonationContext impersonationContext = null;
        if (Thread.CurrentPrincipal.Identity is WindowsIdentity)
        {
            impersonationContext = (Thread.CurrentPrincipal.Identity as WindowsIdentity).Impersonate();
        }
        try
        {
            // access the DB as normal
        }
        catch { /* always handle exceptions in threads */ }
        finally
        {
            if (impersonationContext != null)
            {
                impersonationContext.Undo();
            }
        }
    }
