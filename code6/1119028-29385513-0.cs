            ManagementScope Scope = null;
            string computerName = this.HostName;
            string userName = this.UserName;
            SecureString password = this.Password;
            ManagementObjectCollection collection = null;
            try
            {
                SelectQuery query = new SelectQuery("select * from " + wmiObj.ToString());
                //string query = "SELECT * FROM Win32_NetworkAdapterConfiguration" + " WHERE IPEnabled = 'TRUE'";
                var options = new ConnectionOptions
                {
                    EnablePrivileges = true,
                    Impersonation = ImpersonationLevel.Impersonate,
                    Username = userName,
                    SecurePassword = password
                };
                Scope.Options = options;
                Scope.Connect();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, query);
                collection = searcher.Get();
            }
            catch (ManagementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException(ex.Message);
            }
