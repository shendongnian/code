     public class Impersonator : IDisposable
        {
            #region Win32 Advanced API calls
    
            /// <summary>
            /// Logons the user.
            /// </summary>
            /// <param name="lpszUserName">Name of the LPSZ user.</param>
            /// <param name="lpszDomain">The LPSZ domain.</param>
            /// <param name="lpszPassword">The LPSZ password.</param>
            /// <param name="dwLogOnType">Type of the dw log on.</param>
            /// <param name="dwLogOnProvider">The dw log on provider.</param>
            /// <param name="phToken">The ph token.</param>
            /// <returns></returns>
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true,
                BestFitMapping = false, ThrowOnUnmappableChar = true)]
            private static extern int LogonUser(String lpszUserName,
                    String lpszDomain,
                    String lpszPassword,
                    int dwLogOnType,
                    int dwLogOnProvider,
                    ref IntPtr phToken);
    
            /// <summary>
            /// Duplicates the token.
            /// </summary>
            /// <param name="hToken">The h token.</param>
            /// <param name="impersonationLevel">The impersonation level.</param>
            /// <param name="hNewToken">The h new token.</param>
            /// <returns></returns>
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true,
                BestFitMapping = false, ThrowOnUnmappableChar = true)]
            private static extern int DuplicateToken(IntPtr hToken,
                    int impersonationLevel,
                    ref IntPtr hNewToken);
    
            /// <summary>
            /// Reverts to self.
            /// </summary>
            /// <returns></returns>
            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true,
                BestFitMapping = false, ThrowOnUnmappableChar = true)]
            private static extern bool RevertToSelf();
    
    
            /// <summary>
            /// Closes the handle.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <returns></returns>
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true,
                BestFitMapping = false, ThrowOnUnmappableChar = true)]
            private static extern bool CloseHandle(IntPtr handle);
    
            #endregion
    
            #region Fields
    
            /// <summary>
            /// Field to hold the impersonation Context
            /// </summary>
            WindowsImpersonationContext impersonationContext;
    
            /// <summary>
            /// Track whether Dispose has been called.
            /// </summary>
            private bool disposed;
    
            #region Constants
            /// <summary>
            /// Logon32 Logon Interactive 
            /// </summary>
            public const int INTERACTIVE_NUMBER = 2;
    
            /// <summary>
            /// Logon32 Provider Default
            /// </summary>
            public const int DEFAULT_NUMBER = 0;
    
            /// <summary>
            /// Impersonating user name key
            /// </summary>
            public const string ImpersonatingUserNameKey = "ImpersonatingUserName";
    
            /// <summary>
            /// Impersonating user password key
            /// </summary>
            public const string ImpersonatingPasswordKey = "ImpersonatingUserPassword";
    
            /// <summary>
            /// Impersonating user domain key
            /// </summary>
            public const string ImpersonatingDomainNameKey = "ImpersonatingDomain";
    
            #endregion
    
            #endregion
    
            #region Construction/Destruction/Initialization
    
            /// <summary>
            /// Constructor of the impersonator
            /// </summary>
            public Impersonator()
            {
                if (!ImpersonateUser(ConfigurationManager.AppSettings[ImpersonatingUserNameKey],
                                        ConfigurationManager.AppSettings[ImpersonatingDomainNameKey],
                                        ConfigurationManager.AppSettings[ImpersonatingPasswordKey]))
                {
                    //TODO: Log Exception
                }
            }
    
            #endregion
    
            #region Public Methods
    
            // Implement IDisposable.
            // Do not make this method virtual.
            // A derived class should not be able to override this method.
            public void Dispose()
            {
                Dispose(true);
                // This object will be cleaned up by the Dispose method.
                // Therefore, you should call GC.SupressFinalize to
                // take this object off the finalization queue
                // and prevent finalization code for this object
                // from executing a second time.
                GC.SuppressFinalize(this);
            }
    
            /// <summary>
            /// Impersonate User with the given user credentials
            /// </summary>
            /// <param name="userName">User Name</param>
            /// <param name="domain">Domain</param>
            /// <param name="password">Password</param>
            /// <returns>True if success, false otherwise</returns>
            private bool ImpersonateUser(String userName, String domain, String password)
            {
                WindowsIdentity tempWindowsIdentity;
                IntPtr token = IntPtr.Zero;
                IntPtr tokenDuplicate = IntPtr.Zero;
    
                if (RevertToSelf())
                {
                    if (LogonUser(userName, domain, password, INTERACTIVE_NUMBER,
                            DEFAULT_NUMBER, ref token) != 0)
                    {
                        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                        {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                            impersonationContext = tempWindowsIdentity.Impersonate();
                            if (impersonationContext != null)
                            {
                                CloseHandle(token);
                                CloseHandle(tokenDuplicate);
                                return true;
                            }
                        }
                    }
                }
                if (token != IntPtr.Zero)
                    CloseHandle(token);
                if (tokenDuplicate != IntPtr.Zero)
                    CloseHandle(tokenDuplicate);
                return false;
            }
    
            /// <summary>
            /// Undo impersonation
            /// </summary>
            private void StopImpersonation()
            {
                impersonationContext.Undo();
            }
    
            #endregion
    
            #region Protected Methods
    
            // Dispose(bool disposing) executes in two distinct scenarios.
            // If disposing equals true, the method has been called directly
            // or indirectly by a user's code. Managed and unmanaged resources
            // can be disposed.
            // If disposing equals false, the method has been called by the
            // runtime from inside the finalizer and you should not reference
            // other objects. Only unmanaged resources can be disposed.
            protected virtual void Dispose(bool disposing)
            {
                // Check to see if Dispose has already been called.
                if (!this.disposed)
                {
                    // If disposing equals true, dispose all managed
                    // and unmanaged resources.
                    if (disposing)
                    {
                        StopImpersonation();
                    }
    
                    // Note disposing has been done.
                    disposed = true;
                }
            }
    
            #endregion
        }
