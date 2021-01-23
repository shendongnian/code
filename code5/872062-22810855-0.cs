        private static string CreateConnection()
        {
            Runspace remoteRunspace = null;
            openRunspace(
                "https://pod51057psh.outlook.com/powershell-liveid?PSVersion=3.0",
                "http://schemas.microsoft.com/powershell/Microsoft.Exchange",
                @"xxx@xxx.com",
                "xxxxx",
                ref remoteRunspace
             );
             // Command getLicenseCommand = new Command("Get-MsolAccountSku");
                //Command activityCommand = new Command("Get-GroupActivityReport");
                //activityCommand.Parameters.Add(new CommandParameter("ReportType", "Daily"));
                //activityCommand.Parameters.Add(new CommandParameter("StartDate", "03/4/2014"));
                //activityCommand.Parameters.Add(new CommandParameter("EndDate", "03/27/2014"));
            Command activityCommand = new Command("Get-Mailbox");
            activityCommand.Parameters.Add("-Identity", "xxx");
            StringBuilder stringBuilder = new StringBuilder();
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.Runspace = remoteRunspace;
                powershell.Commands.AddCommand(activityCommand);
                
                powershell.Invoke();
                var results = powershell.Invoke();
                remoteRunspace.Close();
                foreach (PSObject obj in results)
                {
                    stringBuilder.AppendLine(obj.ToString());
                }
            }
            remoteRunspace.Close();
            return stringBuilder.ToString();
        }
        public static void openRunspace(string uri, string schema, string username, string livePass,   ref Runspace remoteRunspace)
        {
            System.Security.SecureString password = new System.Security.SecureString();
            foreach (char c in livePass.ToCharArray())
            {
                password.AppendChar(c);
            }
            PSCredential psc = new PSCredential(username, password);
            WSManConnectionInfo rri = new WSManConnectionInfo(new Uri(uri), schema, psc);
           
            rri.AuthenticationMechanism = AuthenticationMechanism.Basic;
          
            remoteRunspace = RunspaceFactory.CreateRunspace(rri);
            remoteRunspace.Open();
        }
