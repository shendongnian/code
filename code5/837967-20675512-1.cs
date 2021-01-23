    using (DirectoryEntry de = new DirectoryEntry("GC://rootDSE"))
    {
        var rootName = de.Properties["rootDomainNamingContext"].Value.ToString();
        using (var userBinding = new DirectoryEntry("GC://" + rootName))
        {
            using (DirectorySearcher adSearch = new DirectorySearcher(userBinding))
            {
                adSearch.ReferralChasing = ReferralChasingOption.All;
                adSearch.Filter = "(&((&(objectCategory=Person)(objectClass=User)))(samaccountname=" + username + "*))";
                adSearch.PropertiesToLoad.Add("employeeID");
                adSearch.PropertiesToLoad.Add("givenname");
                adSearch.PropertiesToLoad.Add("samaccountname");
                var result = adSearch.FindOne();
                   
                var employeeId = result.Properties["employeeID"] as string;
            }
        }
    }
