    System.Runtime.Hosting.ActivationArguments args = AppDomain.CurrentDomain.SetupInformation.ActivationArguments;
    if (args.ActivationData != null)
    {
        foreach (string commandLineFile in AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData)
        {
            MessageBox.Show(string.Format("Command Line File: {0}", commandLineFile));
        }
    }
