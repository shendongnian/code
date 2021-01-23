    [DllImport("advapi32.dll", SetLastError = true)]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
    
    public enum LogonType
    {
        Interactive = 2,
        Network = 3,
        Batch = 4,
        Service = 5,
        Unlock = 7,
        NetworkClearText = 8,
        NewCredentials = 9,
    }
    
    public enum LogonProvider
    {
        LOGON32_PROVIDER_DEFAULT = 0,
        LOGON32_PROVIDER_WINNT35 = 1,
        LOGON32_PROVIDER_WINNT40 = 2,
        LOGON32_PROVIDER_WINNT50 = 3
    }
    
    public static bool LdapAuthentication(string domain, string user, string password, Configurator cfg)
    {
        try
        {
            LogonType lt = LogonType.Network;
    
            IntPtr token = IntPtr.Zero;
            return (LogonUser(user, domain, password, (int)lt, (int)LogonProvider.LOGON32_PROVIDER_DEFAULT, out token));
        }
        catch
        {
            return (false);
        }
    }
