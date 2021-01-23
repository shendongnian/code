        WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
        connectionInfo.ComputerName = host;
        SecureString securePwd = new SecureString();
        pass.ToCharArray().ToList().ForEach(p => securePwd.AppendChar(p));
        connectionInfo.Credential = new PSCredential(username, securePwd);
        Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
        runspace.Open();
        Collection<PSObject> results = null;
        using (PowerShell ps = PowerShell.Create())
        {
            ps.Runspace = runspace;
            ps.AddScript(cmd);
            results = ps.Invoke();
            // Do something with result ... 
        }
        runspace.Close();
        foreach (var result in results)
        {
            txtOutput.AppendText(result.ToString() + "\r\n");
        }
