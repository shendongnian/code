    private void Button1_Click()
    {
        using(GetImpersonationContext())
        {
            /* code here */
        } 
    }
    private WindowsImpersonationContext GetImpersonationContext()
    {
        IntPtr token = IntPtr.Zero;
        LogonUser("Administrator",
                  "192.168.1.244",
                  "PassWord",
                  (int)LogonType.NewCredentials,
                  (int)LogonProvider.WinNT50,
                  ref token);
        
        WindowsImpersonationContext context = WindowsIdentity.Impersonate(token);
        CloseHandle(token);
        return context;
    }
