    using System.Deployment.Application;
    // e.g. in Form1_Load
    if (ApplicationDeployment.IsNetworkDeployed)
    {
        string[] activationData = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
        if (activationData != null && activationData.Length > 0)
        {
            string[] args = activationData[0].Split(new char[] { ',' });
            if (args.Length > 0)
            {
                // args[0] is first argument
            }
        }
    }
