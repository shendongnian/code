        System.Security.Principal.WindowsImpersonationContext impersonationContext = null;
        try {
            // Get the current identity from the SendMessage parameter and use it to impersonate that user on this thread
            impersonationContext = currentIdentity.Impersonate();
            // Do work
        } finally {
            // Undo the impersonation
            if (impersonationContext != null) {
                impersonationContext.Undo();
            }
        }
