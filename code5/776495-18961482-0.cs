    using System;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using System.Security.Principal;
    using Microsoft.Win32.SafeHandles;
    using System.Runtime.ConstrainedExecution;
    using System.Security;
    using System.Configuration;
    
    namespace ImpersonationUtil
    {
        /// <summary>
        /// Facilitates impersonation of a Windows User.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public class Impersonation : IDisposable
        {
            public string Environment { get; set; }
    
            public string UserName { get; set; }
    
            public string Password { get; set; }
    
            public string DomainName { get; set; }
    
            public enum LogonType
            {
                Interactive = 2,
                Network = 3,
                Batch = 4,
                Service = 5,
                Unlock = 7,
                NetworkClearText = 8,
                NewCredentials = 9
            }
    
            public enum LogonProvider
            {
                Default = 0,
                WinNT35 = 1,
                WinNT40 = 2,
                WinNT50 = 3
            }
    
            /// <summary>
            /// Windows Token.
            /// </summary>
            private readonly SafeTokenHandle _handle;
    
            /// <summary>
            /// The impersonated User.
            /// </summary>
            private WindowsImpersonationContext impersonatedUser;
    
            public Impersonation()
            {
            }
    
            /// <summary>
            /// Initializes a new instance of the Impersonation class. Provides domain, user name, and password for impersonation.
            /// </summary>
            /// <param name="domainName">Domain name of the impersonated user.</param>
            /// <param name="userName">Name of the impersonated user.</param>
            /// <param name="password">Password of the impersonated user.</param>
            /// <remarks>
            /// Uses the unmanaged LogonUser function to get the user token for
            /// the specified user, domain, and password.
            /// </remarks>
            public Impersonation(AccountCredentials credentials)
            {            
                string[] splitName = WindowsIdentity.GetCurrent().Name.Split('\\');
                string name = (splitName.Length > 0) ? splitName[0] : null;
    
                LogonType logonType = LogonType.Interactive;
                LogonProvider logonProvider = LogonProvider.Default;
    
                if (name != credentials.Domain)
                {
                    logonType = LogonType.NewCredentials;
                    logonProvider = LogonProvider.WinNT50;
                }
    
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = LogonUser(
                                    credentials.UserName,
                                    credentials.Domain,
                                    credentials.Password,
                                    (int)logonType,
                                    (int)logonProvider,
                                    out this._handle);
    
                if (false == returnValue)
                {
                    // Something went wrong.
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
    
                this.impersonatedUser = WindowsIdentity.Impersonate(this._handle.DangerousGetHandle());    
            }
    
            /// <summary>
            /// Initializes a new instance of the Impersonation class. Provide domain, user name, and password for impersonation.
            /// </summary>
            /// <param name="domainName">Domain name of the impersonated user.</param>
            /// <param name="userName">Name of the impersonated user.</param>
            /// <param name="password">Password of the impersonated user.</param>
            /// <remarks>
            /// Uses the unmanaged LogonUser function to get the user token for
            /// the specified user, domain, and password.
            /// </remarks>
            public Impersonation(string domainName, string userName, string password)
            {
                string[] splitName = WindowsIdentity.GetCurrent().Name.Split('\\');
                string name = (splitName.Length > 0) ? splitName[0] : null;
    
                LogonType logonType = LogonType.Interactive;
                LogonProvider logonProvider = LogonProvider.Default;
    
                if (name != domainName)
                {
                    logonType = LogonType.NewCredentials;
                    logonProvider = LogonProvider.WinNT50;
                }
    
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = LogonUser(
                                    userName,
                                    domainName,
                                    password,
                                    (int)logonType,
                                    (int)logonProvider,
                                    out this._handle);
    
                if (false == returnValue)
                {
                    // Something went wrong.
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
    
                this.impersonatedUser = WindowsIdentity.Impersonate(this._handle.DangerousGetHandle());
            }
    
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool LogonUser(
                    string lpszUsername,
                    string lpszDomain,
                    string lpszPassword,
                    int dwLogonType,
                    int dwLogonProvider,
                    out SafeTokenHandle phToken);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern bool CloseHandle(IntPtr handle);
    
            public void Dispose()
            {
                this.impersonatedUser.Dispose();
                this._handle.Dispose();
            }
    
            private static string[] GetAccountInfo(string accountInfo)
            {
                return accountInfo.Split(' ');
            }
        }
    
        public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            private SafeTokenHandle()
                : base(true) { }
    
            [DllImport("kernel32.dll")]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            [SuppressUnmanagedCodeSecurity]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr handle);
    
            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }
    }
