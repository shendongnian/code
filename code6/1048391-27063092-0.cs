            DirectorySearcher ds = new DirectorySearcher();
            ds.SearchRoot = new DirectoryEntry("LDAP://" + domain, domain + @"\" + userName, password);
            ds.Filter = "(&(objectClass=user)(cn=*" + key + "*))";
            ds.PropertyNamesOnly = true;
            ds.PropertiesToLoad.Add("name");
            ds.PropertiesToLoad.Add("cn");
            foreach (SearchResult searchResults in ds.FindAll())
            {
                foreach (string propertyName in searchResults.Properties.PropertyNames)
                {
                    foreach (Object retEntry in searchResults.Properties[propertyName])
                    {
                        var user = retEntry.ToString().Split('/').Where(x => x.Contains("CN")).Select(y => y).FirstOrDefault().Split(',').Where(z => z.Contains("CN")).Select(c => c).FirstOrDefault().Split(',').FirstOrDefault().Split('=')[1];
                        if(!string.IsNullOrWhiteSpace(user))
                            userNames.Add(user);
                    }
                }
            }
