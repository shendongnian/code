    namespace curUsers
    {
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();
            //set the privileges
            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.DisplayName = "curUsers";
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "curUsers";
            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }
        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
        }
        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
        }
    }
    }
