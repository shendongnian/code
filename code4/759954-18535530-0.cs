            Process advertise = advertiseMSI(@"c:\temp\test.msi", "JoeWhoHasAdminRights", "Joe'sSuperPassword");
            advertise.WaitForExit();
            Process install = installMSI(@"c:\temp\test.msi");
            install.WaitForExit();
        private static Process advertiseMSI(string msiPath, string userName, string Password)
        {
            Domain domain = Domain.GetCurrentDomain();
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = @"C:\Windows\System32\msiexec.exe";
            process.StartInfo.Arguments = string.Format(@"/jm {0}", msiPath);
            process.StartInfo.WorkingDirectory = Environment.GetEnvironmentVariable("WINDIR");
            process.StartInfo.UserName = userName;
            process.StartInfo.Password = new SecureString();
            foreach (char c in Password.ToCharArray())
            {
                process.StartInfo.Password.AppendChar(c);
            }
            process.StartInfo.Domain = domain.ToString();            
            process.Start();
            return process;
        }
        private static Process installMSI(string msiPath)
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Windows\System32\msiexec.exe";
            process.StartInfo.Arguments = string.Format(@"/i {0} REBOOT=ReallySuppress /qb-", msiPath);
            process.StartInfo.WorkingDirectory = Environment.GetEnvironmentVariable("WINDIR");
            process.Start();
            return process;
        }
