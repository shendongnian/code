    public Task<string> GetUserName(string ComputerName)
    {
        return Task.Run(() =>
        {
            ConnectionOptions conn = ConnectionOptions()
            {
                EnablePrivileges = true,
                Username = // string in format of @"DomainName\UserName",
                Password = password,
                Authentication = AuthenticationLevel.PacketPrivacy,
                Impersonation = ImpersonationLevel.Impersonate
            };
            ManagementScope scope = new ManagementScope(@"\\" + ComputerName + @"\root\cimv2", conn);
            try
            {
                scope.Connect();
                ObjectQuery user = new ObjectQuery("Select UserName From Win32_ComputerSystem");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, user);
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject m in collection)
                {
                    string username = m["UserName"].ToString().Trim();
                    if(!String.IsNullOrEmpty(username))
                    {
                        return username;
                    }
                }
                return null; // no current logged in user
            }
            catch (Exception) // error handling...
        });
    }
