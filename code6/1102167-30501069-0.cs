        try
        {
            var target = new Uri(Uri);
            SecureString PSPassword = new SecureString();
            foreach (char c in ConfigurationManager.AppSettings["Password"])
            {
                PSPassword.AppendChar(c);
            }
            //var cred = (PSCredential)null;
            PSCredential cred = new PSCredential(ConfigurationManager.AppSettings["Username"], PSPassword);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo(target, shell, cred);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Default;
            connectionInfo.OperationTimeout = 1 * 60 * 1000; // 4 minutes.
            connectionInfo.OpenTimeout = 1 * 30 * 1000; // 1 minute.
            using (Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo))
            {
                remoteRunspace.Open();
                using (PowerShell powershell = PowerShell.Create())
                {
                    powershell.Runspace = remoteRunspace;
                    powershell.AddScript(PSSnapin);
                    powershell.Invoke();
                    powershell.Streams.ClearStreams();
                    powershell.Commands.Clear();
                    Pipeline pipeline = remoteRunspace.CreatePipeline();
                    Command getMailBox = new Command("Get-Mailbox");
                    getMailBox.Parameters.Add("Identity", Username);
                    Command cmd = new Command("Select-Object");
                    string[] Parameter = new string[] { "PrimarySMTPAddress" };
                    cmd.Parameters.Add("Property", Parameter);
                    pipeline.Commands.Add(getMailBox);
                    pipeline.Commands.Add(cmd);
                    Collection<PSObject> results = pipeline.Invoke();
                    primarySMTPAddress = results[0].ToString();
                    primarySMTPAddress = primarySMTPAddress.ToUpper().Replace("@{PRIMARYSMTPADDRESS=}", "");
                }
                remoteRunspace.Close();
            }
            return primarySMTPAddress;
        }
        catch
        {
            return "Error";
        }
