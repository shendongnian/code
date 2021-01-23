    // In any class
    public static string GetDeploymentPath()
    {
        return ApplicationDeployment.IsNetworkDeployed
            ? ApplicationDeployment.CurrentDeployment.UpdateLocation
            : String.Empty; // Debug mode
    }
