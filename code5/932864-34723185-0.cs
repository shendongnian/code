    InitialSessionState iss = InitialSessionState.CreateDefault();
                iss.ImportPSModule(new[] { "MSOnline" });
                using (Runspace myRunSpace = RunspaceFactory.CreateRunspace(iss))
                {
                    Pipeline pipeline = myRunSpace.CreatePipeline();
                    myRunSpace.Open();
    
                   
                    // Execute the Get-CsTrustedApplication cmdlet.
                    using (System.Management.Automation.PowerShell powershell = System.Management.Automation.PowerShell.Create())
                    {
                        powershell.Runspace = myRunSpace;
                        Command connect = new Command("Connect-MsolService");
                        System.Security.SecureString secureString = new System.Security.SecureString();
                        string myPassword = "Password";
                        foreach (char c in myPassword)
                            secureString.AppendChar(c);
    
                        connect.Parameters.Add("Credential", new PSCredential("admin@domain.microsoftonline.com", secureString));
                        powershell.Commands.AddCommand(connect);
    
    
                        Collection<PSObject> results = null;
                        Collection<ErrorRecord> errors = null;
                        results = powershell.Invoke();
                        errors = powershell.Streams.Error.ReadAll();
                        powershell.Commands.Clear();
                        Command getuser = new Command("Get-MsolUser");
                        getuser.Parameters.Add("MaxResults", 4);
                        powershell.Commands.AddCommand(getuser);
                        results = null;
                        errors = null;
                        results = powershell.Invoke();
    
                        foreach (PSObject psObject in results)
                        {
                            Console.WriteLine(psObject.Members["DisplayName"].Value.ToString());
                        }
                    }
                }
