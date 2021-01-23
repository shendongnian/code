            string shell = "http://schemas.microsoft.com/powershell/MyShell";
            var target = new Uri("https://myserver:port/wsman");
            var secured = new SecureString();
            foreach (char letter in "password")
            {
                secured.AppendChar(letter);
            }
            secured.MakeReadOnly();
            var credential = new PSCredential("username", secured);
            var connectionInfo = new WSManConnectionInfo(target, shell, credential);
            using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
            {
                runspace.Open();
                using (var ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;
                    ps.AddCommand("Get-NAVServerInstance");
                    var output = ps.Invoke();
                }
            }
