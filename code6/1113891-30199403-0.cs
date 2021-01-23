            var ctx = new DirectoryContext(
                DirectoryContextType.DirectoryServer,
                ipAddress,
                userName, // in the form DOMAIN\UserName or else it would fail for a remote directory server
                password);
            var domain = Domain.GetDomain(ctx);
            var values = new List<string>();
            foreach (DomainController dc in domain.DomainControllers)
            {
                using (var entry =
                        new DirectoryEntry(
                            "LDAP://" + dc.IPAddress,
                            userName,
                            password))
                {
                    using (var search = new DirectorySearcher(entry))
                    {
                        search.Filter = "(&(primaryInternationalISDNNumber=*)(sAMaccountName=" + userName + "))";
                        var result = search.FindOne();
                        var de = result.GetDirectoryEntry();
                        if (de.Properties["primaryInternationalISDNNumber"].Value != null)
                        {
                            values.Add(de.Properties["primaryInternationalISDNNumber"].Value.ToString());
                        }
                    }
                }
            }
