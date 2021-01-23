    Runspace runspace = RunspaceFactory.CreateRunspace(initial);
    runspace.Open();
    
    //First Query
    var firstQuery = PowerShell.Create();
    firstQuery.Runspace = runspace;
    firstQuery.AddScript("Write-Host 'hello'")
    
    //Second Query
    var secondQuery = PowerShell.Create();
    secondQuery.Runspace = runspace;
    secondQuery.AddScript("Write-Host 'world'")
