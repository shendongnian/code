    using System;
    using System.Text;
    using System.IO;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Collections.Generic;
    
    
    namespace EncryptionDecryption
    {
        [RunInstaller(true)]
        public class InstallerClassDemo : Installer
        {
            private string installationDirectory=string.Empty;
            private string testString=string.Empty ;
    
            public override void Install(System.Collections.IDictionary stateSaver)
            {
                base.Install(stateSaver);
    
                try
                {
                    //For testing purpose only.. work only in debug mode when pdb files are deployed as well.
                    //Debugger.Break();
    
                    installationDirectory = Context.Parameters["INSTALLDIR"];
    
                    //I believe, the config file must be located in the installation directory if so, then use the following way to compute path
    
                    string configFilePath = Path.Combine(installationDirectory, "myConfigFile.config");
                    EncrptionHelper.SetValue(configFilePath, "testKey", "testValue");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
    
            }
    
            protected override void OnCommitted(System.Collections.IDictionary savedState)
            {
                base.OnCommitted(savedState);
            }
            
            public override void Uninstall(System.Collections.IDictionary savedState)
            {
                base.Uninstall(savedState);
            }
    
    
        }
    }
