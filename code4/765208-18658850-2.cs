        public static SearchResultCollection FindAccountByEmail(string pEmailAddress)
        {
            string filter = string.Format("(proxyaddresses=SMTP:{0})", email);
            using (DirectoryEntry gc = new DirectoryEntry("LDAP:"))
            {
                foreach (DirectoryEntry z in gc.Children)
                {
                    using (DirectoryEntry root = z)
                    {
                        using (DirectorySearcher searcher = new DirectorySearcher(root, filter, new string[] { "proxyAddresses", "objectGuid", "displayName", "distinguishedName" }))
                        {
                            searcher.ReferralChasing = ReferralChasingOption.All;
                            SearchResultCollection result = searcher.FindAll();
                            return result;
                        }
                    }
                }
            }
            return null;
        }
