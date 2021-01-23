        public void GetSystemInformation(string _yourDomain, string _hostName, string _userName, SecureString _password)
        {
            ManagementScope Scope = null;
            string computerName = _hostName;
            string userName = _userName;
            SecureString password = _password;
            ManagementObjectCollection collection = null;
            try
            {
                SelectQuery query = new SelectQuery("SELECT * FROM Win32_OperatingSystem");
                //string query = "SELECT * FROM Win32_NetworkAdapterConfiguration" + " WHERE IPEnabled = 'TRUE'";
                var options = new ConnectionOptions
                {
                      EnablePrivileges = false,
                      Impersonation = ImpersonationLevel.Impersonate,
                      Username = _userName,
                      SecurePassword = _password,
                      Authority = "ntlmdomain:" + _yourDomain
                };
                Scope.Options = options;
                Scope.Connect();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(Scope, query);
                collection = searcher.Get();
               //Do something with the collection
            }
            catch (ManagementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        private static SecureString CreateSecuredString(string pw)
        {
            var secureString = new SecureString();
            foreach (var c in pw)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }
