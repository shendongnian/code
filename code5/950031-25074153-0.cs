    [RunInstaller(true)]
    public partial class InstallerActions : System.Configuration.Install.Installer
    {
        public InstallerActions()
        {
            InitializeComponent();
        }
        //Code to perform at the time of installing application
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            //if (Debugger.IsAttached == false) Debugger.Launch();
            CustomParameters cParams = new CustomParameters();
            cParams.Add("InstallPath", this.Context.Parameters["targetdir"]);
            cParams.SaveState(stateSaver);
            //Continue with install process
            base.Install(stateSaver);
        }
        //Code to perform at the time of uninstalling application 
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            //if (Debugger.IsAttached == false) Debugger.Launch();
            CustomParameters cParams = new CustomParameters(savedState);
            string sBase = cParams.GetValue("InstallPath");
            //Continue with uninstall process
            base.Uninstall(savedState);
            try
            {
                //Delete all files in the base folder recursively except service or exe files
                string[] files = System.IO.Directory.GetFiles(sBase, "*.*", System.IO.SearchOption.AllDirectories);
                foreach (string f in files)
                {
                    //Check the extention of the filename first
                    string sExt = Path.GetExtension(f).ToLower();
                    if (sExt != ".installstate" && sExt != ".exe")
                    {
                        FileAttributes attr = File.GetAttributes(f);
                        File.SetAttributes(f, attr & ~FileAttributes.ReadOnly);
                        System.IO.File.Delete(f);
                    }
                }
                
                //This would delete the base install directory but
                //the installer will do this instead, I just need to
                //clean up everything I made other the the exe's and
                //service files
                //System.IO.Directory.Delete(sBase, true);
            }
            catch
            {
                //Error, just ignore it
            }
        }
    }
