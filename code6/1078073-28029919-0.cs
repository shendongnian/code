    [DllImport("advapi32.DLL", SetLastError = true)]
    public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);
    [DllImport("advapi32.DLL")]
    public static extern bool ImpersonateLoggedOnUser(IntPtr hToken);  
    [DllImport("advapi32.DLL")]
    public static extern bool RevertToSelf();
    public static object Impersonate(string username, string password)
    {
        string domainname = ".";
        if (username.Contains(@"\"))
        {
            domainname = username.Substring(0, username.IndexOf(@"\"));
            username = username.Substring(username.IndexOf(@"\") + 1);
        }
        IntPtr securityToken;
        LogonUser(username, domainname, password, 9, 0, out securityToken);
        if (securityToken != IntPtr.Zero)
        {
            var newIdentity = new WindowsIdentity(securityToken);
            WindowsImpersonationContext impersonationContext = newIdentity.Impersonate();
            return impersonationContext;
        }
        throw new InvalidOperationException("The username or password combination was invalid, please verify your settings");
    }
    public static void UndoImpersonation(object impersonationContext)
    {
        var context = impersonationContext as WindowsImpersonationContext;
        if (context != null) context.Undo();
    }
