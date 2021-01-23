    PSCredential newCred = (PSCredential)null;
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("http://exchangeserver01.my.domain/powershell?serializationLevel=Full"), 
        "http://schemas.microsoft.com/powershell/Microsoft.Exchange", newCred);
    connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
    PowerShell powershell = PowerShell.Create();
                             
    PSCommand command = new PSCommand();
    command.AddCommand("Enable-Mailbox");
    command.AddParameter("Identity", user.Guid.ToString());
    command.AddParameter("Alias", user.UserName);
    command.AddParameter("DomainController", ConnectingServer);
    powershell.Commands = command;
     
    try
    {
        runspace.Open();
        powershell.Runspace = runspace;
        Collection<psobject> results = powershell.Invoke();
    }
    catch (Exception ex)
    {
        string er = ex.InnerException.ToString();
    }
    finally
    {
        runspace.Dispose();
        runspace = null;
     
        powershell.Dispose();
        powershell = null;
    }
