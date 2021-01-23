    if (ApplicationDeployment.IsNetworkDeployed)
    {
        ApplicationDeployment applicationDeployment = ApplicationDeployment.CurrentDeployment;
    
        Version version = applicationDeployment.CurrentVersion;
    
        return  String.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
    }
