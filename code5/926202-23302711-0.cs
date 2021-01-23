        public static Collection<PSObject> remoteExchangePowerShell(string domain, string username, SecureString password, string remoteFQDNServer)
        {
            PSCredential remoteCredential = new PSCredential(string.Format("{0}\\{1}", domain, username), password);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(string.Format("http://{0}/Powershell?serializationLevel=Full", remoteFQDNServer)), 
                "http://schemas.microsoft.com/powershell/Microsoft.Exchange", remoteCredential);
            
            /*Just for PowerShell
             WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(string.Format("http://{0}/Powershell?serializationLevel=Full", remoteFQDNServer) + ":5985/wsman"),
                 "http://schemas.microsoft.com/powershell/Microsoft.PowerShell", remoteCredential);*/
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            using (Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo))
            {
                //remoteRunspace.Open();
                using (PowerShell powershell = PowerShell.Create())
                {
                    PSSnapInException psException;
                    powershell.Runspace.RunspaceConfiguration.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out psException);
                    ....
                }
            }
        }
