            var remoteComputer = new Uri(String.Format("{0}://{1}:5985/wsman", "HTTP", "ComputerName"));
            var connection = new WSManConnectionInfo(remoteComputer, null, TopTest.GetCredential());
            var runspace = RunspaceFactory.CreateRunspace(connection);
            runspace.Open();
            var powershell = PowerShell.Create();
            powershell.Runspace = runspace;
            powershell.AddScript("$env:ComputerName");
            var result = powershell.Invoke();
