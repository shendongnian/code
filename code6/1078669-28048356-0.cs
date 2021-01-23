    PSCredential credentials = new PSCredential(userName, password);
    
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo(
        new Uri("https://outlook.office365.com/PowerShell-LiveID"),
        "http://schemas.microsoft.com/powershell/Microsoft.Exchange",
        credentials);
    
    connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
    
    using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
    {
        using (PowerShell powershell = PowerShell.Create())
        {
            powershell.AddCommand("Get-User");
            powershell.AddParameter("ResultSize", 50);
    
            runspace.Open();
            powershell.Runspace = runspace;
    
            Collection<PSObject> results = powershell.Invoke();
    
            Console.WriteLine("Results: {0}", results.Count);
        }
    }
