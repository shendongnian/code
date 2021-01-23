    private static bool IsElevated()
    {
         var user = WindowsIdentity.GetCurrent();
         var role = WindowsPrincipal(user);
         if(Environment.OSVersion.Platform == PlatformID.Win32NT || Environment.OSVersion.Version.Major > 6)
               if(user != null)
                    if(role.IsInRole(WindowsBuiltInRole.Administrator))
                         return true;
    
         return false;
    }
