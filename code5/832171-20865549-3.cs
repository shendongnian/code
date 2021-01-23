    private void button1_Click(object sender, EventArgs e)
    {
        //If we're an administrator, then do it
        if (IsUserAnAdmin())
        {
            StartService("bthserv"); //"Bluetooth Support Service" for my sample test code
            return;
        }
        //We're not running as an administrator.
        //Relaunch ourselves as admin, telling us that we want to start the service
        ExecuteAsAdmin(Application.ExecutablePath, "/serviceStart");
    }
    //helper function that tells us if we're already running with administrative rights
    private Boolean IsUserAnAdmin()
    {
        //A user can be a member of the Administrator group, but not an administrator.
        //Conversely, the user can be an administrator and not a member of the administrators group.
        //Check if the current user has administrative privelages
        var identity = WindowsIdentity.GetCurrent();
        return (null != identity && new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator));
    }
    private void ExecuteAsAdmin(string Filename, string Arguments)
    {
       //Launch process elevated
       ProcessStartInfo startInfo = new ProcessStartInfo(Filename, Arguments);
       startInfo.Verb = "runas"; //the runas verb is the secret to making UAC prompt come up
       System.Diagnostics.Process.Start(startInfo);
    }
