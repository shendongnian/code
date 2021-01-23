    using (ImpersonationManager impersonationManager = new ImpersonationManager())
    {
        impersonationManager.Impersonate(Settings.Default.MediaAccessDomain, 
            Settings.Default.MediaAccessUserName, Settings.Default.MediaAccessPassword);
        // Perform restricted action as other user with higher permissions here
    }
