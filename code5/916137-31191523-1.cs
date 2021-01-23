    var username = "foobar";
    var domain = "";
    var connInfo = new WSManConnectionInfo(false, hostname, Port, AppName, ShellUri,
                    new PSCredential(domain + "\\" + username, password))
                {
                    AuthenticationMechanism = AuthenticationMechanism.Negotiate
                };
    
    using (var runspace = RunspaceFactory.CreateRunspace(host, connectionInfo))
    {
        runspace.Open(); //will try to negotiate with Kerberos in domain, NTLM in non-domain
    }
