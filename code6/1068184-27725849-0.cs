        // this method will return all groups where the the user is a direct and indirect member of
        public static bool getTokenGroups(string domainFQDN, string alias, ref List<string> userGroups)
        {
            bool result = false;
            try
            {
                SearchResult sr = default(SearchResult);
                using (DirectoryEntry domainDE = new DirectoryEntry("LDAP://" + domainFQDN, "domain\\cn", "password", AuthenticationTypes.Secure))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(domainDE))
                    {
                        searcher.Filter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", alias);
                        sr = searcher.FindOne();
                        if (sr != null)
                        {
                            using (DirectoryEntry user = sr.GetDirectoryEntry())
                            {
                                user.RefreshCache(new string[] { "tokenGroups" });
                                for (int i = 0; i < user.Properties["tokenGroups"].Count; i++)
                                {
                                    SecurityIdentifier sid = new SecurityIdentifier((byte[])user.Properties["tokenGroups"][i], 0);
                                    NTAccount nt = (NTAccount)sid.Translate(typeof(NTAccount));
                                    //do something with the SID or name (nt.Value)
                                    if(nt.Value.IndexOf('\\') > -1)
                                        userGroups.Add(nt.Value.Split('\\')[1]);
                                    else
                                        userGroups.Add(nt.Value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("source name", MethodBase.GetCurrentMethod().DeclaringType + "." + MethodBase.GetCurrentMethod().Name + "\r\n\r\nUnable to get user's token groups for domain: " + domainFQDN + " user: " + alias + "\r\n\r\n" + ex.Message, EventLogEntryType.Error);
            }
            return result;
        }
