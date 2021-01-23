    using (Runspace remoteRunspace = RunspaceFactory.CreateRunspace(setUpConnection()))
    {
        remoteRunspace.Open();
        using (PowerShell powershell = PowerShell.Create())
        {
            powershell.Runspace = remoteRunspace;
    
            DateTime dateTime = (DateTime)powershell.Invoke().Single().BaseObject;
        }
        // No need to close runspace; you are disposing it.
    }
