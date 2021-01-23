    using Microsoft.Deployment.WindowsInstaller;
    
    public static void Uninstall( string productCode)
    {
       Installer.SetInternalUI(InstallUIOptions.Silent);
       Installer.ConfigureProduct(productCode, 0, InstallState.Absent, "REBOOT=\"R\" /L*V! c:\uninstall.log");
    }
