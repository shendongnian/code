    public bool ValidateUser(string domain, string username, string password,string LdapPath, out string Errmsg)
            {
                Errmsg = "";
                string domainAndUsername = domain + @"\" + username;
                DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password);
                try
                {
                    // Bind to the native AdsObject to force authentication.
                    Object obj = entry.NativeObject;
                    DirectorySearcher search = new DirectorySearcher(entry);
                    search.Filter = "(SAMAccountName=" + username + ")";
                    search.PropertiesToLoad.Add("cn");
                    SearchResult result = search.FindOne();
                    if (null == result)
                    {
                        return false;
                    }
                    // Update the new path to the user in the directory
                    LdapPath = result.Path;
                    string _filterAttribute = (String)result.Properties["cn"][0];
                }
                catch (Exception ex)
                {
                    Errmsg = ex.Message;
                    return false;
                    throw new Exception("Error authenticating user." + ex.Message);
                }
                return true;
            }
     
