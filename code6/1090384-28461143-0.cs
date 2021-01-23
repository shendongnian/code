        public static List<string> GetAllUsers()
        {
            List<string> users = new List<string>();
          
            using (DirectoryEntry de = new DirectoryEntry("LDAP://OU=Users,DC=example,DC=local"))
            {
                using (DirectorySearcher ds = new DirectorySearcher(de))
                {
                    ds.Filter = "objectClass=user";
                    SearchResultCollection src = ds.FindAll();
                    foreach (SearchResult sr in src)
                    {
                        using (DirectoryEntry user = new DirectoryEntry(sr.Path))
                        {
                            users.Add(new string(user.Properties["sAMAccountName"][0].ToString()));
                           
                        }
                    }
                }
               
            }
            return users;
        }
