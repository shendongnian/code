    class Impersonation : IDisposable
        {
            public static Impersonation Impersonate()
            {
                return new Impersonation();
            }
    
            private WindowsImpersonationContext ImpersonationContext { get; set; }
    
            private Impersonation()
            {
                var currentIdentity = System.Threading.Thread.CurrentPrincipal.Identity as WindowsIdentity;
                if (currentIdentity != null && currentIdentity.IsAuthenticated)
                {
                    ImpersonationContext = currentIdentity.Impersonate();
                    return;
                }
                throw new SecurityException("Could not impersonate user identity");
            }
            public void Dispose()
            {
                if(ImpersonationContext != null)
                    ImpersonationContext.Dispose();
            }
        }
    }
