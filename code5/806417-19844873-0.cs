    //Just use the Class Method no need to instantiate it:
    ApplicationLoader.CreateProcessAsUser(string filename, string args)
    [SuppressUnmanagedCodeSecurity]
    class ApplicationLoader
    {
        /// <summary>
        /// No Need to create the class.
        /// </summary>
        private ApplicationLoader() { }
  
        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId,
            TokenGroupsAndPrivileges,
            TokenSessionReference,
            TokenSandBoxInert,
            TokenAuditPolicy,
            TokenOrigin,
            TokenElevationType,
            TokenLinkedToken,
            TokenElevation,
            TokenHasRestrictions,
            TokenAccessInformation,
            TokenVirtualizationAllowed,
            TokenVirtualizationEnabled,
            TokenIntegrityLevel,
            TokenUIAccess,
            TokenMandatoryPolicy,
            TokenLogonSid,
            MaxTokenInfoClass
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 dwProcessID;
            public Int32 dwThreadID;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public Int32 Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }
        public enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous,
            SecurityIdentification,
            SecurityImpersonation,
            SecurityDelegation
        }
        public enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation
        }
        public const int GENERIC_ALL_ACCESS = 0x10000000;
        public const int CREATE_NO_WINDOW = 0x08000000;
        [DllImport("advapi32.dll", EntryPoint = "ImpersonateLoggedOnUser", SetLastError = true,
              CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ImpersonateLoggedOnUser(IntPtr hToken);
        [
           DllImport("kernel32.dll",
              EntryPoint = "CloseHandle", SetLastError = true,
              CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)
        ]
        public static extern bool CloseHandle(IntPtr handle);
        [
           DllImport("advapi32.dll",
              EntryPoint = "CreateProcessAsUser", SetLastError = true,
              CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)
        ]
        public static extern bool
           CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine,
                               ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes,
                               bool bInheritHandle, Int32 dwCreationFlags, IntPtr lpEnvrionment,
                               string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo,
                               ref PROCESS_INFORMATION lpProcessInformation);
        [
           DllImport("advapi32.dll",
              EntryPoint = "DuplicateTokenEx")
        ]
        public static extern bool
           DuplicateTokenEx(IntPtr hExistingToken, Int32 dwDesiredAccess,
                            ref SECURITY_ATTRIBUTES lpThreadAttributes,
                            Int32 ImpersonationLevel, Int32 dwTokenType,
                            ref IntPtr phNewToken);
        [DllImport("Kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.U4)]
        public static extern IntPtr WTSGetActiveConsoleSessionId();
        [DllImport("advapi32.dll")]
        public static extern IntPtr SetTokenInformation(IntPtr TokenHandle, IntPtr TokenInformationClass, IntPtr TokenInformation, IntPtr TokenInformationLength);
        [DllImport("wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSQueryUserToken(uint sessionId, out IntPtr Token);
        private static int getCurrentUserSessionID()
        {
            uint dwSessionId = (uint)WTSGetActiveConsoleSessionId();
            //Gets the ID of the User logged in with WinLogOn
            Process[] processes = Process.GetProcessesByName("winlogon");
            foreach (Process p in processes)
            {
                if ((uint)p.SessionId == dwSessionId)
                {
                    //this is the process controlled by the same sessionID
                    return p.SessionId; 
                }
            }
            return -1;
        }
 
        /// <summary>
        /// Actually calls and creates the application.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static Process CreateProcessAsUser(string filename, string args)
        {
            //var replaces IntPtr
            var hToken = WindowsIdentity.GetCurrent().Token; //gets Security Token of Current User.
            
            var hDupedToken = IntPtr.Zero;
            var pi = new PROCESS_INFORMATION();
            var sa = new SECURITY_ATTRIBUTES();
            sa.Length = Marshal.SizeOf(sa);
            try
            {
                if (!DuplicateTokenEx(
                        hToken,
                        GENERIC_ALL_ACCESS,
                        ref sa,
                        (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                        (int)TOKEN_TYPE.TokenPrimary,
                        ref hDupedToken
                    ))
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                var si = new STARTUPINFO();
                si.cb = Marshal.SizeOf(si);
                si.lpDesktop = "";
                var path = Path.GetFullPath(filename);
                var dir = Path.GetDirectoryName(path);
                //Testing
                uint curSessionid = (uint)ApplicationLoader.getCurrentUserSessionID();
                if (!WTSQueryUserToken(curSessionid,out hDupedToken))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                // Revert to self to create the entire process; not doing this might
                // require that the currently impersonated user has "Replace a process
                // level token" rights - we only want our service account to need
                // that right.
                using (var ctx = WindowsIdentity.Impersonate(IntPtr.Zero))
                {
                    if (!CreateProcessAsUser(
                                            hDupedToken,
                                            path,
                                            string.Format("\"{0}\" {1}", filename.Replace("\"", "\"\""), args),
                                            ref sa, ref sa,
                                            false, CREATE_NO_WINDOW, IntPtr.Zero,
                                            dir, ref si, ref pi
                                    ))
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                return Process.GetProcessById(pi.dwProcessID);
            }
            finally
            {
                if (pi.hProcess != IntPtr.Zero)
                    CloseHandle(pi.hProcess);
                if (pi.hThread != IntPtr.Zero)
                    CloseHandle(pi.hThread);
                if (hDupedToken != IntPtr.Zero)
                    CloseHandle(hDupedToken);
            }
        }
    }
