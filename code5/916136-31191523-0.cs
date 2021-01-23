    var username = "foobar";
    var connInfo = new WSManConnectionInfo(false, hostname, Port, AppName, ShellUri,
                    new PSCredential(username, password))
                {
                    AuthenticationMechanism = AuthenticationMechanism.Negotiate
                };
    
    using (var runspace = RunspaceFactory.CreateRunspace(host, connectionInfo))
    {
        runspace.Open(); //will try to negotiate with Kerberos
    }
