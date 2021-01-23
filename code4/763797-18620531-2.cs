    var password = "HelloWorld";
    var ss = new SecureString();
    foreach (var passChar in password)
    {
        ss.AppendChar(passChar);
    }
    var psCredential = new PSCredential("username", ss);
    var connectionInfo = new WSManConnectionInfo(new Uri("http://localhost:5985/wsman"), "http://schemas.microsoft.com/powershell/Microsoft.PowerShell", psCredential);
    using (var runspace = RunspaceFactory.CreateRunspace(connectionInfo))
    {
        connectionInfo.EnableNetworkAccess = true;
        using (var powershell = PowerShell.Create())
        {
