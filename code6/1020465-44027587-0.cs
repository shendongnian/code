    /// <summary>
    /// Base on code found here:
    /// http://stackoverflow.com/questions/1220213/c-detect-if-running-with-elevated-privileges
    /// </summary>
    public static class UacHelper
    {
        private const string uacRegistryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
        private const string uacRegistryValue = "EnableLUA";
    
        private const uint STANDARD_RIGHTS_READ = 0x00020000;
        private const uint TOKEN_QUERY = 0x0008;
        private const uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
    
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);
    
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool GetTokenInformation(IntPtr TokenHandle, TOKEN_INFORMATION_CLASS TokenInformationClass,
            IntPtr TokenInformation, uint TokenInformationLength,
            out uint ReturnLength);
    
        public enum TOKEN_INFORMATION_CLASS
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
    
        public enum TOKEN_ELEVATION_TYPE
        {
            TokenElevationTypeDefault = 1,
            TokenElevationTypeFull,
            TokenElevationTypeLimited
        }
    
        private static bool? _isUacEnabled;
    
        public static bool IsUacEnabled
        {
            get
            {
                if (_isUacEnabled == null)
                {
                    var uacKey = Registry.LocalMachine.OpenSubKey(uacRegistryKey, false);
                    if (uacKey == null)
                    {
                        _isUacEnabled = false;
                    }
                    else
                    {
                        var enableLua = uacKey.GetValue(uacRegistryValue);
                        _isUacEnabled = enableLua.Equals(1);
                    }
                }
                return _isUacEnabled.Value;
            }
        }
    
        private static bool? _isAdministrator;
    
        public static bool IsAdministrator
        {
            get
            {
                if (_isAdministrator == null)
                {
                    var identity = WindowsIdentity.GetCurrent();
                    Debug.Assert(identity != null);
                    var principal = new WindowsPrincipal(identity);
                    _isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
                return _isAdministrator.Value;
            }
        }
    
        private static bool? _isProcessElevated;
    
        public static bool IsProcessElevated
        {
            get
            {
                if (_isProcessElevated == null)
                {
                    if (IsUacEnabled)
                    {
                        var process = Process.GetCurrentProcess();
    
                        IntPtr tokenHandle;
                        if (!OpenProcessToken(process.Handle, TOKEN_READ, out tokenHandle))
                        {
                            throw new ApplicationException("Could not get process token.  Win32 Error Code: " +
                                                           Marshal.GetLastWin32Error());
                        }
    
                        var elevationResult = TOKEN_ELEVATION_TYPE.TokenElevationTypeDefault;
    
                        var elevationResultSize = Marshal.SizeOf((int) elevationResult);
                        uint returnedSize;
                        var elevationTypePtr = Marshal.AllocHGlobal(elevationResultSize);
    
                        var success = GetTokenInformation(tokenHandle, TOKEN_INFORMATION_CLASS.TokenElevationType,
                            elevationTypePtr, (uint) elevationResultSize, out returnedSize);
                        if (!success)
                        {
                            Marshal.FreeHGlobal(elevationTypePtr);
                            throw new ApplicationException("Unable to determine the current elevation.");
                        }
    
                        elevationResult = (TOKEN_ELEVATION_TYPE) Marshal.ReadInt32(elevationTypePtr);
                        Marshal.FreeHGlobal(elevationTypePtr);
    
                        // Special test for TokenElevationTypeDefault.
                        // If the current user is the default Administrator, then the
                        // process is also assumed to run elevated. This is assumed 
                        // because by default the default Administrator (which is disabled by default) 
                        //  gets all access rights even without showing a UAC prompt.
                        switch (elevationResult)
                        {
                            case TOKEN_ELEVATION_TYPE.TokenElevationTypeFull:
                                _isProcessElevated = true;
                                break;
                            case TOKEN_ELEVATION_TYPE.TokenElevationTypeLimited:
                                _isProcessElevated = false;
                                break;
                            default:
                                // Will come here if either
                                // 1. We are running as the default Administrator.
                                // 2. We were started using "Run as administrator" from a non-admin
                                //    account and logged on as the default Administrator account from
                                //    the list of available Administrator accounts.
                                //
                                // Note: By default the default Administrator account always behaves 
                                //       as if UAC was turned off. 
                                //
                                // This can be controlled through the Local Security Policy editor 
                                // (secpol.msc) using the 
                                // "User Account Control: Use Admin Approval Mode for the built-in Administrator account"
                                // option of the Security Settings\Local Policies\Security Options branch.
                                _isProcessElevated = IsAdministrator;
                                break;
                        }
                    }
                    else
                    {
                        _isProcessElevated = IsAdministrator;
                    }
                }
                return _isProcessElevated.Value;
            }
        }
    }
