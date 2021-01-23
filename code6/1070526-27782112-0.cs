    // at application start
    var identity = WindowsIdentity.GetCurrent();
    var principal = new WindowsPrincipal(identity);
    bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
    // if not admin - elevate
    if(!isAdmin)
    {
        var info = new ProcessStartInfo(Application.ExecutablePath) { Verb = "runas" };
        Process.Start(info);
        return; // exit
    }
    // if we are here - application runs as admin
    ...
