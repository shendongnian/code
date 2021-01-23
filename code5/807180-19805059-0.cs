    public bool ActiveDirectoryAuthenticate(string username, string password)
        {
            var result = false;
            using (
                var entry = new DirectoryEntry("LDAP://PT/DC=pt,DC=biz", username, password,
                    AuthenticationTypes.Secure))
            {
                var searcher = new DirectorySearcher(entry) {Filter = "sAMAccountName=Bank.Members"};
                searcher.PropertiesToLoad.Add("distinguishedName");
                try
                {
                    var sr = searcher.FindOne();
                    var name = sr.Properties["distinguishedName"][0].ToString();
                    result = true;
                }
                catch (Exception exception)
                {
                }
            }
            return result;
        }
