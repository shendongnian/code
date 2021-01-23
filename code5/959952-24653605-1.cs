    using System.Deployment.Application;
    
        public Version Version 
        {
            get
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
        }
    
    
        string versionNumber = Version.Major.ToString() + "." + Version.Minor.ToString() + "." + Version.Build.ToString() + "." + Version.Revision.ToString();
