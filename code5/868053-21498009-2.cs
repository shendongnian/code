    private void RunImpersonated(Action act)
    {
        IntPtr token = IntPtr.Zero;
        LogonUser("Administrator",
                  "192.168.1.244",
                  "PassWord",
                  (int)LogonType.NewCredentials,
                  (int)LogonProvider.WinNT50,
                  ref token);
        try
        {
            using (WindowsImpersonationContext context = WindowsIdentity.Impersonate(token))
            {
                // Call action
                act();
            }
        }
        finally
        {
            CloseHandle(token);
        }
    }
