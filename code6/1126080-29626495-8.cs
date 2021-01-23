    public IEnumerable<ManagementObject> GetSystemInformation()
    {
            ManagementScope scope = new ManagementScope(String.Format("\\\\{0}\\root\\cimv2", "hostname"));
            ManagementObjectCollection collection = null;
            //BEGIN: This part you will need if you want to acces other computers in your network you might wanna comment this part.
            string computerName = "Hostname";
            string userName = "username";
            string password = "ThePW";
            try
            {
                var options = new ConnectionOptions
                {
                    Authentication = AuthenticationLevel.Packet,
                    EnablePrivileges = true,
                    Impersonation = ImpersonationLevel.Impersonate,
                    Username = this.UserName,
                    SecurePassword = this.Password,
                    Authority = "ntlmdomain:" + Environment.UserDomainName
                };
                scope.Options = options;
                //END: Part which you need to connect to remote pc
                SelectQuery query = new SelectQuery("select * from Win32_NetworkAdapterConfiguration");
       
                Scope.Connect();
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
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
            if (collection == null) { yield break; }
            foreach (ManagementObject obj in collection)
            {
                yield return obj;
            }
     }
     public IEnumerable<PropertyData> GetPropertiesOfManagmentObj(ManagementObject obj)
     {
           var properties = obj.Properties;
           foreach (PropertyData item in properties)
           {
                yield return item;
           }
    
           yield break;
     }
