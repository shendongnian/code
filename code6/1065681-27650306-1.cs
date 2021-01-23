        DirectoryEntry de = new DirectoryEntry("LDAP://domain.com/dc=domain,dc=com", "user", "pwd");
        DirectorySearcher srch = new DirectorySearcher(de);
        srch.Filter = "(&(objectCategory=person)(objectClass=user)(!(name=*Joe*)))";
        srch.SearchScope = SearchScope.Subtree;
        // add the attributes
        srch.PropertiesToLoad.Add("distinguishedName");
        using (SearchResultCollection results = srch.FindAll())
        {
            foreach (SearchResult result in results)
            {
                string dn = result.Properties["distinguishedName"][0] as string;
                Console.WriteLine("- {0}", dn);
            }
        }
