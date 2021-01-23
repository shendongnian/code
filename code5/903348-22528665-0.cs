    private string GetPublishedVersion()
    {
        if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
        {
            return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.
                CurrentVersion.ToString();
        }
        return "Not network deployed";
    }
