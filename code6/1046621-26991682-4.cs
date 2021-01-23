    using System;
    using System.Configuration.Install;
    using System.ComponentModel;
    using System.ServiceProcess;
    using System.IO;
    using System.Net.Sockets;
    using System.Net;
    using System.Threading;
    using System.Configuration;
    using System.Diagnostics;
    
    /// <summary>
    /// Installerklasse für den Service
    /// </summary>
    [RunInstaller(true)]
    public class QServiceInstaller : Installer
    {
        #region private Member
        private ServiceInstaller myThisService;
        private IContainer components;
        private ServiceProcessInstaller myThisServiceProcess;
        #endregion
    
        public QServiceInstaller()
        {
            myThisService = new ServiceInstaller();
            myThisServiceProcess = new ServiceProcessInstaller();
            
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    
            myThisServiceProcess.Account = ServiceAccount.LocalSystem;
            myThisService.ServiceName = "Your application name";
            myThisService.StartType = ServiceStartMode.Automatic;
            
            Installers.Add(myThisService);
            Installers.Add(myThisServiceProcess);
        }
    
        private void InitializeComponent()
        {
    
        }
    }
