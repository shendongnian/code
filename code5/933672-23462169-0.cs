    string version = null;
    try
    {   
        //// get deployment version
        version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
    }
    catch (InvalidDeploymentException)
    {
        //// you cannot read publish version when app isn't installed 
        //// (e.g. during debug)
        version = "not installed";
    }
