    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
    {
         var deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
         var uri = deploy.ActivationUri;
         // Also:
         //deploy.DataDirectory
         //deploy.UpdateLocation
    }
