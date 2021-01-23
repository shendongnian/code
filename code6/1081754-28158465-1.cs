    class AccessShareAsLoggedOnUser
    {
        public static bool CopyAsLocalUser(String sourceFile, string targetFile)
        {
            uint dwSessionId, winlogonPid = 0;
            IntPtr hUserToken = IntPtr.Zero, hUserTokenDup = IntPtr.Zero, hPToken = IntPtr.Zero, hProcess = IntPtr.Zero;
            Debug.Print("CreateProcessInConsoleSession");
            // Log the client on to the local computer.
            dwSessionId = WTSGetActiveConsoleSessionId();
            // Find the winlogon process
            var procEntry = new PROCESSENTRY32();
            uint hSnap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
            if (hSnap == INVALID_HANDLE_VALUE)
            {
                return false;
            }
            procEntry.dwSize = (uint)Marshal.SizeOf(procEntry); //sizeof(PROCESSENTRY32);
            if (Process32First(hSnap, ref procEntry) == 0)
            {
                return false;
            }
            String strCmp = "explorer.exe";
            do
            {
                if (strCmp.IndexOf(procEntry.szExeFile) == 0)
                {
                    // We found a winlogon process...make sure it's running in the console session
                    uint winlogonSessId = 0;
                    if (ProcessIdToSessionId(procEntry.th32ProcessID, ref winlogonSessId) &&
                        winlogonSessId == dwSessionId)
                    {
                        winlogonPid = procEntry.th32ProcessID;
                        break;
                    }
                }
            }
            while (Process32Next(hSnap, ref procEntry) != 0);
            //Get the user token used by DuplicateTokenEx
            WTSQueryUserToken(dwSessionId, ref hUserToken);
            hProcess = OpenProcess(MAXIMUM_ALLOWED, false, winlogonPid);
            if (
                !OpenProcessToken(hProcess,
                    TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY | TOKEN_DUPLICATE | TOKEN_ASSIGN_PRIMARY
                    | TOKEN_ADJUST_SESSIONID | TOKEN_READ | TOKEN_WRITE, ref hPToken))
            {
                Debug.Print(String.Format("CreateProcessInConsoleSession OpenProcessToken error: {0}",
                    Marshal.GetLastWin32Error()));
            }
            var sa = new SECURITY_ATTRIBUTES();
            sa.Length = Marshal.SizeOf(sa);
            if (!DuplicateTokenEx(hPToken, MAXIMUM_ALLOWED, ref sa,
                    (int)SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, (int)TOKEN_TYPE.TokenPrimary,
                    ref hUserTokenDup))
            {
                Debug.Print(
                    String.Format(
                        "CreateProcessInConsoleSession DuplicateTokenEx error: {0} Token does not have the privilege.",
                        Marshal.GetLastWin32Error()));
                CloseHandle(hProcess);
                CloseHandle(hUserToken);
                CloseHandle(hPToken);
                return false;
            }
            try
            {
                using (WindowsImpersonationContext impersonationContext =
                    new WindowsIdentity(hUserTokenDup).Impersonate())
                {
                // Put your network Code here.
                    File.WriteAllText(targetFile // Somewhere with right permissions like @"C:\Users\xxx\output.txt"
                          , File.ReadAllText(sourceFile)); // like @"\\server\share\existingfile.txt"
                    impersonationContext.Undo();
                }
                return true;
            }
            finally
            {
                if (hUserTokenDup != IntPtr.Zero)
                {
                    if (!CloseHandle(hUserTokenDup))
                    {
                        // Uncomment if you need to know this case.
                        ////throw new Win32Exception();
                    }
                }
                //Close handles task
                CloseHandle(hProcess);
                CloseHandle(hUserToken);
                CloseHandle(hUserTokenDup);
                CloseHandle(hPToken);
            }
        }
        [DllImport("kernel32.dll")]
        private static extern int Process32First(uint hSnapshot, ref PROCESSENTRY32 lppe);
        [DllImport("kernel32.dll")]
        private static extern int Process32Next(uint hSnapshot, ref PROCESSENTRY32 lppe);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hSnapshot);
        [DllImport("kernel32.dll")]
        private static extern uint WTSGetActiveConsoleSessionId();
        [DllImport("Wtsapi32.dll")]
        private static extern uint WTSQueryUserToken(uint SessionId, ref IntPtr phToken);
        [DllImport("kernel32.dll")]
        private static extern bool ProcessIdToSessionId(uint dwProcessId, ref uint pSessionId);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
        [DllImport("advapi32", SetLastError = true)]
        [SuppressUnmanagedCodeSecurity]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, // handle to process
            int DesiredAccess, // desired access to process
            ref IntPtr TokenHandle);
        [DllImport("advapi32.dll", EntryPoint = "DuplicateTokenEx")]
        public static extern bool DuplicateTokenEx(IntPtr ExistingTokenHandle, uint dwDesiredAccess,
            ref SECURITY_ATTRIBUTES lpThreadAttributes, int TokenType,
            int ImpersonationLevel, ref IntPtr DuplicateTokenHandle);
        #region Nested type: PROCESSENTRY32
        [StructLayout(LayoutKind.Sequential)]
        private struct PROCESSENTRY32
        {
            public uint dwSize;
            public readonly uint cntUsage;
            public readonly uint th32ProcessID;
            public readonly IntPtr th32DefaultHeapID;
            public readonly uint th32ModuleID;
            public readonly uint cntThreads;
            public readonly uint th32ParentProcessID;
            public readonly int pcPriClassBase;
            public readonly uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public readonly string szExeFile;
        }
        #endregion
        #region Nested type: SECURITY_ATTRIBUTES
        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int Length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }
        #endregion
        #region Nested type: SECURITY_IMPERSONATION_LEVEL
        private enum SECURITY_IMPERSONATION_LEVEL
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3,
        }
        #endregion
        #region Nested type: TOKEN_TYPE
        private enum TOKEN_TYPE
        {
            TokenPrimary = 1,
            TokenImpersonation = 2
        }
        #endregion
        public const int READ_CONTROL = 0x00020000;
        public const int STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        public const int STANDARD_RIGHTS_READ = READ_CONTROL;
        public const int STANDARD_RIGHTS_WRITE = READ_CONTROL;
        public const int STANDARD_RIGHTS_EXECUTE = READ_CONTROL;
        public const int STANDARD_RIGHTS_ALL = 0x001F0000;
        public const int SPECIFIC_RIGHTS_ALL = 0x0000FFFF;
        public const int TOKEN_ASSIGN_PRIMARY = 0x0001;
        public const int TOKEN_DUPLICATE = 0x0002;
        public const int TOKEN_IMPERSONATE = 0x0004;
        public const int TOKEN_QUERY = 0x0008;
        public const int TOKEN_QUERY_SOURCE = 0x0010;
        public const int TOKEN_ADJUST_PRIVILEGES = 0x0020;
        public const int TOKEN_ADJUST_GROUPS = 0x0040;
        public const int TOKEN_ADJUST_DEFAULT = 0x0080;
        public const int TOKEN_ADJUST_SESSIONID = 0x0100;
        public const int TOKEN_READ = STANDARD_RIGHTS_READ | TOKEN_QUERY;
        public const int TOKEN_WRITE = STANDARD_RIGHTS_WRITE |
                                       TOKEN_ADJUST_PRIVILEGES |
                                       TOKEN_ADJUST_GROUPS |
                                       TOKEN_ADJUST_DEFAULT;
        public const uint MAXIMUM_ALLOWED = 0x2000000;
        private const uint TH32CS_SNAPPROCESS = 0x00000002;
        public static int INVALID_HANDLE_VALUE = -1;
        // handle to open access token
    }
