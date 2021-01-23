     String url = "http://" + ExchangeServerName + "/powershell?serializationLevel=Full";
            System.Uri uri = new Uri(url);
            Console.WriteLine(url);
            System.Security.SecureString securePassword = String2SecureString(password);
            System.Management.Automation.PSCredential creds = new System.Management.Automation.PSCredential(userName, securePassword);
            Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace();
            PowerShell powershell = PowerShell.Create();
            PSCommand command = new PSCommand();
            command.AddCommand("New-PSSession");
            command.AddParameter("ConfigurationName", "Microsoft.Exchange");
            command.AddParameter("ConnectionUri", uri);
            command.AddParameter("Credential", creds);
            command.AddParameter("Authentication", Authentication);
            //PSSessionOption sessionOption = new PSSessionOption();
            //sessionOption.SkipCACheck = true;
            //sessionOption.SkipCNCheck = true;
            //sessionOption.SkipRevocationCheck = true;
            //command.AddParameter("SessionOption", sessionOption);
            powershell.Commands = command;
            try
            {
                runspace.Open();
                powershell.Runspace = runspace;
                Collection<PSSession> result = powershell.Invoke<PSSession>();
                foreach (ErrorRecord current in powershell.Streams.Error)
                    Console.WriteLine("The following Error happen when opening the remote Runspace: " + current.Exception.ToString() +
                                                                                " | InnerException: " + current.Exception.InnerException);
                if (result.Count != 1)
                    throw new System.Exception("Unexpected number of Remote Runspace connections returned.");
                // Set the runspace as a local variable on the runspace
                powershell = PowerShell.Create();
                command = new PSCommand();
                command.AddCommand("Set-Variable");
                command.AddParameter("Name", "ra");
                command.AddParameter("Value", result[0]);
                powershell.Commands = command;
                powershell.Runspace = runspace;
                powershell.Invoke();
                // First import the cmdlets in the current runspace (using Import-PSSession)
                powershell = PowerShell.Create();
                command = new PSCommand();
                //command.AddScript("Import-PSSession $ra");
                command.AddScript("Invoke-Command -ScriptBlock { Get-Mailbox -Identity:" + MailBoxName + " } -Session $ra");
                powershell.Commands = command;
                powershell.Runspace = runspace;
                //powershell.Commands.AddCommand("Import-Module").AddArgument("activedirectory");
                powershell.Invoke();
                //command = new PSCommand();
                //command.AddCommand("Get-Mailbox");
                ////Change the name of the database
                //command.AddParameter("Identity", "");
                //powershell.Commands = command;
                //powershell.Runspace = runspace;
                Collection<PSObject> results = new Collection<PSObject>();
                results = powershell.Invoke();
