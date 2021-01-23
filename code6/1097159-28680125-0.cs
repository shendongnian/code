    class NativeMethods
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct PROCESS_INFORMATION
            {
                public IntPtr hProcess;
                public IntPtr hThread;
                public System.UInt32 dwProcessId;
                public System.UInt32 dwThreadId;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct SECURITY_ATTRIBUTES
            {
                public System.UInt32 nLength;
                public IntPtr lpSecurityDescriptor;
                public bool bInheritHandle;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct STARTUPINFO
            {
                public System.UInt32 cb;
                public string lpReserved;
                public string lpDesktop;
                public string lpTitle;
                public System.UInt32 dwX;
                public System.UInt32 dwY;
                public System.UInt32 dwXSize;
                public System.UInt32 dwYSize;
                public System.UInt32 dwXCountChars;
                public System.UInt32 dwYCountChars;
                public System.UInt32 dwFillAttribute;
                public System.UInt32 dwFlags;
                public short wShowWindow;
                public short cbReserved2;
                public IntPtr lpReserved2;
                public IntPtr hStdInput;
                public IntPtr hStdOutput;
                public IntPtr hStdError;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct PROFILEINFO
            {
                public int dwSize;
                public int dwFlags;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpUserName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpProfilePath;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpDefaultPath;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpServerName;
                [MarshalAs(UnmanagedType.LPTStr)]
                public string lpPolicyPath;
                public IntPtr hProfile;
            }
    
            internal enum SECURITY_IMPERSONATION_LEVEL
            {
                SecurityAnonymous = 0,
                SecurityIdentification = 1,
                SecurityImpersonation = 2,
                SecurityDelegation = 3
            }
    
            internal enum TOKEN_TYPE
            {
                TokenPrimary = 1,
                TokenImpersonation = 2
            }
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, ref PROCESS_INFORMATION lpProcessInformation);
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, ref SECURITY_ATTRIBUTES lpTokenAttributes, SECURITY_IMPERSONATION_LEVEL ImpersonationLevel, TOKEN_TYPE TokenType, ref IntPtr phNewToken);
    
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool OpenProcessToken(IntPtr ProcessHandle, int DesiredAccess, ref IntPtr TokenHandle);
    
            [DllImport("userenv.dll", SetLastError = true)]
            private static extern bool CreateEnvironmentBlock(ref IntPtr lpEnvironment, IntPtr hToken, bool bInherit);
    
            [DllImport("userenv.dll", SetLastError = true)]
            private static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);
    
            private const short SW_SHOW = 1;
            private const short SW_SHOWMAXIMIZED = 7;
            private const int TOKEN_QUERY = 8;
            private const int TOKEN_DUPLICATE = 2;
            private const int TOKEN_ASSIGN_PRIMARY = 1;
            private const int GENERIC_ALL_ACCESS = 268435456;
            private const int STARTF_USESHOWWINDOW = 1;
            private const int STARTF_FORCEONFEEDBACK = 64;
            private const int CREATE_UNICODE_ENVIRONMENT = 0x00000400;
            private const string gs_EXPLORER = "explorer";
    
            public static void LaunchProcess(string Ps_CmdLine)
            {
                IntPtr li_Token = default(IntPtr);
                IntPtr li_EnvBlock = default(IntPtr);
                Process[] lObj_Processes = Process.GetProcessesByName(gs_EXPLORER);
    
                // Get explorer.exe id
    
                // If process not found
                if (lObj_Processes.Length == 0)
                {
                    // Exit routine
                    return;
                }
    
                // Get primary token for the user currently logged in
                li_Token = GetPrimaryToken(lObj_Processes[0].Id);
    
                // If token is nothing
                if (li_Token.Equals(IntPtr.Zero))
                {
                    // Exit routine
                    return;
                }
    
                // Get environment block
                li_EnvBlock = GetEnvironmentBlock(li_Token);
    
                // Launch the process using the environment block and primary token
                LaunchProcessAsUser(Ps_CmdLine, li_Token, li_EnvBlock);
    
                // If no valid enviroment block found
                if (li_EnvBlock.Equals(IntPtr.Zero))
                {
                    // Exit routine
                    return;
                }
    
                // Destroy environment block. Free environment variables created by the 
                // CreateEnvironmentBlock function.
                DestroyEnvironmentBlock(li_EnvBlock);
            }
    
            private static IntPtr GetPrimaryToken(int Pi_ProcessId)
            {
    
                IntPtr li_Token = IntPtr.Zero;
                IntPtr li_PrimaryToken = IntPtr.Zero;
                bool lb_ReturnValue = false;
                Process lObj_Process = Process.GetProcessById(Pi_ProcessId);
                SECURITY_ATTRIBUTES lObj_SecurityAttributes = default(SECURITY_ATTRIBUTES);
    
                // Get process by id
                // Open a handle to the access token associated with a process. The access token 
                // is a runtime object that represents a user account.
                lb_ReturnValue = OpenProcessToken(lObj_Process.Handle, TOKEN_DUPLICATE, ref li_Token);
    
                // If successfull in opening handle to token associated with process
                if (lb_ReturnValue)
                {
                    // Create security attributes to pass to the DuplicateTokenEx function
                    lObj_SecurityAttributes = new SECURITY_ATTRIBUTES();
                    lObj_SecurityAttributes.nLength = Convert.ToUInt32(Marshal.SizeOf(lObj_SecurityAttributes));
    
                    // Create a new access token that duplicates an existing token. This function 
                    // can create either a primary token or an impersonation token.
                    lb_ReturnValue = DuplicateTokenEx(li_Token, Convert.ToUInt32(TOKEN_ASSIGN_PRIMARY | TOKEN_DUPLICATE | TOKEN_QUERY), ref lObj_SecurityAttributes, SECURITY_IMPERSONATION_LEVEL.SecurityIdentification, TOKEN_TYPE.TokenPrimary, ref li_PrimaryToken);
    
                    // If un-successful in duplication of the token
                    if (!lb_ReturnValue)
                    {
                        // Throw exception
                        throw new Exception(string.Format("DuplicateTokenEx Error: {0}", Marshal.GetLastWin32Error()));
                    }
                }
                else
                {
                    // If un-successful in opening handle for token then throw exception
                    throw new Exception(string.Format("OpenProcessToken Error: {0}", Marshal.GetLastWin32Error()));
                }
    
                // Return primary token
                return li_PrimaryToken;
            }
    
            private static IntPtr GetEnvironmentBlock(IntPtr Pi_Token)
            {
    
                IntPtr li_EnvBlock = IntPtr.Zero;
                bool lb_ReturnValue = CreateEnvironmentBlock(ref li_EnvBlock, Pi_Token, false);
    
                // Retrieve the environment variables for the specified user. 
                // This block can then be passed to the CreateProcessAsUser function.
    
                // If not successful in creation of environment block then  
                if (!lb_ReturnValue)
                {
                    // Throw exception
                    throw new Exception(string.Format("CreateEnvironmentBlock Error: {0}", Marshal.GetLastWin32Error()));
                }
    
                // Return the retrieved environment block
                return li_EnvBlock;
            }
    
            private static void LaunchProcessAsUser(string Ps_CmdLine, IntPtr Pi_Token, IntPtr Pi_EnvBlock)
            {
                bool lb_Result = false;
                PROCESS_INFORMATION lObj_ProcessInformation = default(PROCESS_INFORMATION);
                SECURITY_ATTRIBUTES lObj_ProcessAttributes = default(SECURITY_ATTRIBUTES);
                SECURITY_ATTRIBUTES lObj_ThreadAttributes = default(SECURITY_ATTRIBUTES);
                STARTUPINFO lObj_StartupInfo = default(STARTUPINFO);
    
                // Information about the newly created process and its primary thread.
                lObj_ProcessInformation = new PROCESS_INFORMATION();
    
                // Create security attributes to pass to the CreateProcessAsUser function
                lObj_ProcessAttributes = new SECURITY_ATTRIBUTES();
                lObj_ProcessAttributes.nLength = Convert.ToUInt32(Marshal.SizeOf(lObj_ProcessAttributes));
                lObj_ThreadAttributes = new SECURITY_ATTRIBUTES();
                lObj_ThreadAttributes.nLength = Convert.ToUInt32(Marshal.SizeOf(lObj_ThreadAttributes));
    
                // To specify the window station, desktop, standard handles, and appearance of the 
                // main window for the new process.
                lObj_StartupInfo = new STARTUPINFO();
                lObj_StartupInfo.cb = Convert.ToUInt32(Marshal.SizeOf(lObj_StartupInfo));
                lObj_StartupInfo.lpDesktop = null;
                lObj_StartupInfo.dwFlags = Convert.ToUInt32(STARTF_USESHOWWINDOW | STARTF_FORCEONFEEDBACK);
                lObj_StartupInfo.wShowWindow = SW_SHOW;
    
                // Creates a new process and its primary thread. The new process runs in the 
                // security context of the user represented by the specified token.
                lb_Result = CreateProcessAsUser(Pi_Token, null, Ps_CmdLine, ref lObj_ProcessAttributes, ref lObj_ThreadAttributes, true, CREATE_UNICODE_ENVIRONMENT, Pi_EnvBlock, null, ref lObj_StartupInfo, ref lObj_ProcessInformation);
    
                // If create process return false then
                if (!lb_Result)
                {
                    // Throw exception
                    throw new Exception(string.Format("CreateProcessAsUser Error: {0}", Marshal.GetLastWin32Error()));
                }
            }
        }
