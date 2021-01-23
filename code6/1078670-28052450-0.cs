    string un = @"domain\username";
                System.Security.SecureString pw = new System.Security.SecureString();
                string password = "password";
                string databaseName = "databasename";
                string exchangeServerName = "http://exchangeserver.com/powershell";
                string microsoftSchemaName = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
                foreach (char ch in password)
                {
                    pw.AppendChar(ch);
                }
                PSCredential cred = new PSCredential(un, pw);
    
                WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(exchangeServerName), microsoftSchemaName, cred);
                connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    
                using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
                {
                    using (PowerShell powershell = PowerShell.Create())
                    {
                        powershell.AddCommand("Get-Mailboxdatabasecopystatus");
                        powershell.AddParameter("identity", databaseName);
                        powershell.AddCommand("select-object");
                        var props = new string[] { "name", "status" };
                        powershell.AddParameter("property", props);
                        runspace.Open();
                        powershell.Runspace = runspace;
    
                        Collection<PSObject> results = powershell.Invoke();
    
                        foreach (PSObject result in results)
                        {
                            MessageBox.Show(result.ToString());
                        }
                    }
                }
                
