    System.Security.Principal.WindowsImpersonationContext impersonationContext;
    impersonationContext = ((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate();
    
    try
    {
        // Do your writing to the AD here
    }
    finally
    {
        impersonationContext.Undo();
    }
