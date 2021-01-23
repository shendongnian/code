    [CmdletProvider("MyPowerShellProvider", ProviderCapabilities.None)]
    public class MyPowerShellProvider : NavigationCmdletProvider
    {
    
        protected override bool IsValidPath(string path)
        {
            return true;
        }
    
        protected override Collection<PSDriveInfo> InitializeDefaultDrives()
        {
            PSDriveInfo drive = new PSDriveInfo("MyDrive", this.ProviderInfo, "", "", null);
            Collection<PSDriveInfo> drives = new Collection<PSDriveInfo>() {drive};
            return drives;
        }
    
        protected override bool ItemExists(string path)
        {
            return true;
        }
    
        protected override bool IsItemContainer(string path)
        {
            return true;
        }
    
        protected override void GetChildItems(string path, bool recurse)
        {
            WriteItemObject("Hello", "Hello", true);
        }
    }
