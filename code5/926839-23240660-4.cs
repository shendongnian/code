    if (ApplicationDeployment.IsNetworkDeployed)
    {
        bool updateIsAvailable;
    
        try
        {
            updateIsAvailable = CheckForUpdateAvailable();
        }
        catch
        {
            //not network deployed etc...
        }
    
        if (updateIsAvailable)
        {
            ad = ApplicationDeployment.CurrentDeployment;
            if (ad == null)
            {
                return;
            }
            ad.Update();
            Application.Restart();
        }
    }   
