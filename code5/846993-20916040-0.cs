        private void DoLogin()
        {
            var token = LogonAsUser(userName, domain, password);
            if (!IntPtr.Equals(token, IntPtr.Zero))
            {
                WindowsImpersonationContext impersonatedUser = null;
                try
                {
                    var newIdentity = new WindowsIdentity(token);
                    impersonatedUser = newIdentity.Impersonate();
                    // Do impersonated work here
                }
                finally
                {
                    if (impersonatedUser != null)
                    {
                        impersonatedUser.Undo();
                    }
                    LogonAsUserEnd(token);
                }
            }
        }
        private IntPtr LogonAsUser(String userName, String domain, String password)
        {
            IntPtr token = IntPtr.Zero;
            if (LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                return token;
            }
            else
            {
                return IntPtr.Zero;
            }
        }
        
        private void LogonAsUserEnd(IntPtr token) {
            if (!IntPtr.Equals(token, IntPtr.Zero))
            {
                CloseHandle(token);
            }
            
        }
